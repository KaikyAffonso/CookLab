using CookLab.Model;
using CookLab.Repository.Recipes;
using CookLab.Repository.RecipesIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.RecipesIngredients
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private IRecipeIngredientRepository repository;

        public RecipeIngredientService(IRecipeIngredientRepository repository)
        {
            this.repository=repository;
        }

        public RecipeIngredient Create(RecipeIngredient recipeIngredient)
        {
            return repository.Create(recipeIngredient);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public RecipeIngredient Retrieve(int id)
        {
           return repository.Retrieve(id);
        }

        public List<RecipeIngredient> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public RecipeIngredient Update(RecipeIngredient recipeIngredient)
        {
            return repository.Update(recipeIngredient);
        }
    }
}
