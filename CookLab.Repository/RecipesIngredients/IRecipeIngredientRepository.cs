using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.RecipesIngredients
{
    public interface IRecipeIngredientRepository
    {
        RecipeIngredient Create(RecipeIngredient recipeIngredient);
        RecipeIngredient Retrieve(int id);
        List<RecipeIngredient> RetrieveAll();
        RecipeIngredient Update(RecipeIngredient recipeIngredient);
        void Delete(int id);
    }
}
