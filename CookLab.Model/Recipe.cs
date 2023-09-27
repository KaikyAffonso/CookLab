using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; } // UserId

        public List<RecipeIngredient> Ingredients { get; set; }
        public Category Category { get; set; }
        public int PrepTime { get; set; }
        public string PrepMethod { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsApproved { get; set; }

    }
}
