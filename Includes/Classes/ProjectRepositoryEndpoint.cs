using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Classes.Github;
using OneClickZip.Includes.Interface.API;
using OneClickZip.Includes.Models.Types;
using OneClickZip.Includes.Resources;

namespace OneClickZip.Includes.Classes
{
    public class ProjectRepositoryEndpoint : IRepositoryHook
    {
        private RepositoryEndpointDomain repositoryEndpointDomain;
        private IRepositoryHook repositoryHookImplementor;

        public ProjectRepositoryEndpoint(RepositoryEndpointDomain repoDomain = RepositoryEndpointDomain.GITHUB)
        {
            this.repositoryEndpointDomain = repoDomain;
            CommonInitialization();
        }

        private void CommonInitialization()
        {
            switch (repositoryEndpointDomain)
            {
                case RepositoryEndpointDomain.GITHUB:
                    repositoryHookImplementor = new GithubRestApi();
                    break;
                default:
                    break;
            }
        }

        public IRepositoryRelease RepositoryLatestRelease()
        {
            return this.repositoryHookImplementor?.RepositoryLatestRelease();
        }

        public bool IsApplicationVersionUpToDate(IRepositoryRelease release)
        {
            try
            {
                //sample format => RELEASE_V_1_0_3
                String[] serverVersion = release.ReleaseTagName.ToUpper().Replace("RELEASE_V_", "").Split(Char.Parse("_"));
                String[] appVersion = ApplicationSettings.ApplicationVersionSplitted;

                for (int ctr = 0; ctr < serverVersion.Length; ctr++)
                {
                    int version = int.Parse(serverVersion[ctr]);
                    int appver = int.Parse(appVersion[ctr]);
                    if (version > appver) return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

    }
}
