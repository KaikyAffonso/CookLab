using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class User
    {
        public int id { get; set; } 
        public string name { get; set; }   
        public string userName { get; set; }
        public string email { get; set; }   
        public string password { get; set; }
        public bool admin { get; set; }
        public bool blocked { get; set; }

    }
}
