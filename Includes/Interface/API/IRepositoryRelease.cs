using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Interface.API
{
    public interface IRepositoryRelease
    {
        String ReleaseTagName { get; }
        String ReleaseURL { get; }
        String ReleaseNote { get; }
    }
}
