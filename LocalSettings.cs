using Landaumedia.CommandCenter.Bootstrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    class LocalSettings : SettingsBase
    {
        public LocalSettings()
        {
            Environment = "Development";
        }
    }
}
