using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }   
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Blocked { get; set; }

    }
}
