using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public partial class ConfigApp
    {
        public CfgConnection DBConnection { get; set; }
        public class CfgConnection
        {
            public string Connection { get; set; }
            public string Server { get; set; }
            public string Port { get; set; }
            public string DataBase { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public string Aditional { get; set; }
        }
    }
}
