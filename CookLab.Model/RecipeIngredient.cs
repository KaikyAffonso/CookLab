using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Model
{
    public class RecipeIngredient
    {
        public int id {  get; set; }    
        public int idRecipe { get; set; }    
        public int idIngredient { get; set; }
        public int idMeasure { get; set; }
        public decimal quantity { get; set; }   
          
    }
}
