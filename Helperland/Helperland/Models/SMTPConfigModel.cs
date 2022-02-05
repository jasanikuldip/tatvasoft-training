using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class SMTPConfigModel
    {
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string Username { get; set; }
        public string host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSSl { get; set; }
        public bool UseDefaultCredential { get; set; }
        public bool IsBodyHTML { get; set; }
    }
}
