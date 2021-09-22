using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public partial class ConfigApp
    {
        public CfgMailServer MailServer { get; set; }
        public class CfgMailServer
        {
            public string Server { get; set; }
            public string Sender { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public int Port { get; set; }
            public bool SSL { get; set; }
        }
    }
}
