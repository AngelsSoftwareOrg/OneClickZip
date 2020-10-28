using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Interface.API;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Models.API
{
    public class GithubEndpointModel : IRepositoryEndpoint
    {
        private static GithubEndpointModel githubEndpointModel;
        private String releaseEndpoint;


        private GithubEndpointModel()
        {
            //build release endpoint
            releaseEndpoint = String.Format(DomainEndpoint +
                Properties.Settings.Default.github_api_endpoint_latest_release,
                OrganizationName, RepositoryName);
        }

        public static IRepositoryEndpoint GetInstance()
        {
            if (githubEndpointModel == null)
            {
                githubEndpointModel = new GithubEndpointModel();
            }
            return githubEndpointModel;
        }

        public string DomainEndpoint
        {
            get
            {
                return Properties.Settings.Default.github_api_endpoint;
            }
        }

        public string LatestReleaseEndpoint
        {
            get
            {
                return releaseEndpoint;
            }
        }

        public string OrganizationName
        {
            get
            {
                return ApplicationSettings.ApplicationOrganizationName;
            }
        }

        public string RepositoryName
        {
            get
            {
                return ApplicationSettings.ApplicationName;
            }
        }

        public string UserName
        {
            get
            {
                return Properties.Settings.Default.github_username;
            }
        }

        public string AccessToken
        {
            get
            {
                return Properties.Settings.Default.github_access_token;
            }
        }
    }
}
