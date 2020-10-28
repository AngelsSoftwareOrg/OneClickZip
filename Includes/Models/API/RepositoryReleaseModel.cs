using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneClickZip.Includes.Interface.API;

namespace OneClickZip.Includes.Models.API
{
    public class RepositoryReleaseModel : IRepositoryRelease
    {
        private String releaseTagName;
        private String releaseURL;
        private String releaseNote;
        public string SetReleaseTagName { set => releaseTagName = value; }
        public string SetReleaseURL { set => releaseURL = value; }
        public string SetReleaseNote { set => releaseNote = value; }
        public string ReleaseTagName
        {
            get
            {
                return releaseTagName;
            }
        }
        public string ReleaseURL
        {
            get
            {
                return releaseURL;
            }
        }
        public string ReleaseNote
        {
            get
            {
                return releaseNote;
            }
        }

    }
}
