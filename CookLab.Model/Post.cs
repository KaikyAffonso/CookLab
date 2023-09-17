using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class Post
    {
        public int id { get; set; }
        public int idUser { get; set; }    

        public int idRecipe { get; set; }
        public string comment { get; set; }
        public int rating { get; set; } 


    }
}
