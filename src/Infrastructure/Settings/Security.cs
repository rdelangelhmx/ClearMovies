using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public partial class ConfigApp
    {
        public CfgAuthSecurity Security { get; set; }
        public class CfgAuthSecurity
        {
            public string Policy { get; set; }
            public string Cors { get; set; }
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public string SecurityKey { get; set; }
            public int Duration { get; set; }
        }
    }
}
