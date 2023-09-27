using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.RecipesIngredients
{
    public interface IRecipeIngredientService
    {
        RecipeIngredient Create(RecipeIngredient recipeIngredient);
        RecipeIngredient Retrieve(int id);
        List<RecipeIngredient> RetrieveAll();
        RecipeIngredient Update(RecipeIngredient recipeIngredient);
        void Delete(int id);
        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId);
        public void DeleteAllByRecipeId(int recipeId);
    }
}
