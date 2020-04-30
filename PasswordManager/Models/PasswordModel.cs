using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class PasswordModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public string tag { get; set; }
        public string notes { get; set; }
        public string dots { get; } = "*********";
    }
}
