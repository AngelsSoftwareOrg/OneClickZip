using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Interface.API
{
    public interface IRepositoryHook
    {
        IRepositoryRelease RepositoryLatestRelease();
    }
}
