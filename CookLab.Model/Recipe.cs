using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class Recipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public int idUser { get; set; }
        public int idCategory { get; set; }
        public int prepTime { get; set; }
        public string prepMethod { get; set; }
        public int idDifficulty { get; set; }
        public bool approved { get; set; }

    }
}
