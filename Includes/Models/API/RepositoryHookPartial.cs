using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace OneClickZip.Includes.Models.API
{
    public partial class RepositoryHookPartial
    {
        private Object InvokeHttpClientGet(UriParametersModel paramModel)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(paramModel.UriString);

                foreach(String userAgent in paramModel.GetUserAgent())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
                }

                // Add an Accept header for JSON format.
                foreach (MediaTypeWithQualityHeaderValue mediaType in paramModel.GetMediaTypeWithQualityHeaderValueList())
                {
                    client.DefaultRequestHeaders.Accept.Add(mediaType);
                }

                // List data response.
                // Blocking call! Program will wait here until a response is received or a timeout occurs.
                using (HttpResponseMessage response = client.GetAsync(paramModel.GetUriParametersString).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body.
                        Object data = response.Content.ReadAsAsync<Object>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                        return data;
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            }
            return null;
        }

        protected Object InvokeWebCallUriAsJson(UriParametersModel paramModel)
        {
            paramModel.AddMediaType("application/json");
            dynamic jsonString = InvokeHttpClientGet(paramModel);
            return jsonString;
        }


    }
}
