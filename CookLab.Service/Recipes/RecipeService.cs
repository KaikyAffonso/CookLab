using CookLab.Model;
using CookLab.Repository.Recipes;
using CookLab.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Recipes
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository repository;

        public RecipeService(IRecipeRepository repository)
        {
            this.repository=repository;
        }

        public Recipe Create(Recipe recipe)
        {
            return repository.Create(recipe);
        }

        public void Delete(int id)
        {
           repository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
           return repository.Retrieve(id);
        }

        public List<Recipe> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public Recipe Update(Recipe recipe)
        {
            return repository.Update(recipe);   
        }
    }
}
