using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Interface.API;
using OneClickZip.Includes.Models;
using OneClickZip.Includes.Models.API;

namespace OneClickZip.Includes.Classes.Github
{
    public class GithubRestApi : RepositoryHookPartial, IRepositoryHook
    {
        private IRepositoryEndpoint githubEndpoint;

        public GithubRestApi()
        {
            githubEndpoint = GithubEndpointModel.GetInstance();
        }

        public IRepositoryRelease RepositoryLatestRelease()
        {
            UriParametersModel urlParametersModel = new UriParametersModel(githubEndpoint.LatestReleaseEndpoint);
            CompleteUriParameterModel(ref urlParametersModel);
            dynamic jsonobj = InvokeWebCallUriAsJson(urlParametersModel);
            
            if (jsonobj == null) throw new NullReferenceException("Repository endpoint didnt respond...");

            RepositoryReleaseModel repoModel = new RepositoryReleaseModel();
            repoModel.SetReleaseNote = jsonobj?.body;
            repoModel.SetReleaseTagName = jsonobj?.tag_name;
            repoModel.SetReleaseURL = jsonobj?.assets?[0].browser_download_url;
            return repoModel;
        }

        private void CompleteUriParameterModel(ref UriParametersModel uriParametersModel)
        {
            uriParametersModel.AddUserAgent("request");
        }

    }
}
