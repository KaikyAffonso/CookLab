using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class Favorite
    {
        public int id { get; set; } 
        public int idUser { get; set; }
        public int idRecipe { get; set; }
    }
}
