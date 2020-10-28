using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Interface.API
{
    public interface IRepositoryEndpoint
    {
        String LatestReleaseEndpoint { get; }
        String OrganizationName { get; }
        String RepositoryName { get; }
        String DomainEndpoint { get; }
        String UserName { get; }
        String AccessToken { get; }

    }
}
