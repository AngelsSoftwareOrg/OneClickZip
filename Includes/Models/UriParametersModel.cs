using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Models
{
    public class UriParametersModel
    {
        private readonly string uriString;
        private List<KeyValuePair<String, String>> parametersList;
        private List<String> mediaTypeList;
        private List<String> userAgentList;
        private HttpMethod httpMethod;
        public UriParametersModel(String uriString, HttpMethod webMethod = null)
        {
            this.uriString = uriString;
            this.parametersList = new List<KeyValuePair<string, string>>();
            this.mediaTypeList = new List<string>();
            this.userAgentList = new List<string>();
            this.httpMethod = (webMethod==null) ? HttpMethod.Get : webMethod;
        }
        public string UriString { 
            get => uriString;
        }
        public Uri GetUri
        {
            get => new Uri(uriString);
        }
        public void AddParameter(String key, String value)
        {
            KeyValuePair<String, String> kvp = new KeyValuePair<string, string>(key, value);
            parametersList.Add(kvp);
        }
        public void ClearParameters()
        {
            parametersList.Clear();
        }
        public String GetUriParametersString
        {
            get
            {
                if (parametersList.Count <= 0) return "";
                StringBuilder strBuilder = new StringBuilder("?");
                foreach (KeyValuePair<String, String> kvp in parametersList)
                {
                    if (strBuilder.Length > 1) strBuilder.Append("&");
                    strBuilder.Append(kvp.Key);
                    strBuilder.Append("=");
                    strBuilder.Append(kvp.Value);
                }
                return strBuilder.ToString(); ;
            }
        }
        public void AddMediaType(String mediaType)
        {
            mediaTypeList.Add(mediaType);
        }
        public void ClearMediaType()
        {
            mediaTypeList.Clear();
        }
        public List<MediaTypeWithQualityHeaderValue> GetMediaTypeWithQualityHeaderValueList()
        {
            List<MediaTypeWithQualityHeaderValue> list = new List<MediaTypeWithQualityHeaderValue>();
            foreach(String mediaType in mediaTypeList){
                list.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            }
            return list;
        }
        public void AddUserAgent(String userAgent)
        {
            userAgentList.Add(userAgent);
        }
        public void ClearUserAgent()
        {
            userAgentList.Clear();
        }
        public List<String> GetUserAgent()
        {
            return this.userAgentList.ToList<String>();
        }
    
    }
}
