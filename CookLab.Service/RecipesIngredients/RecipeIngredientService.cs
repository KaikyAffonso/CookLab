using CookLab.Model;
using CookLab.Repository.Recipes;
using CookLab.Repository.RecipesIngredients;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using CookLab.Service.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.RecipesIngredients
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _repository;
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;
        public RecipeIngredientService(IRecipeIngredientRepository repository, IRecipeService recipeService, IIngredientService ingredientService,IMeasureService measureService)
        {
            _repository=repository;
            _recipeService=recipeService;
            _ingredientService=ingredientService;
            _measureService=measureService;
        }

        public RecipeIngredient Create(RecipeIngredient recipeIngredient)
        {
            return _repository.Create(recipeIngredient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public RecipeIngredient Retrieve(int id)
        {
           RecipeIngredient recipeIngredient = _repository.Retrieve(id);
            recipeIngredient.Recipe = _recipeService.Retrieve(recipeIngredient.Recipe.Id);
            recipeIngredient.Ingredient = _ingredientService.Retrieve(recipeIngredient.Ingredient.Id);
            recipeIngredient.Measure = _measureService.Retrieve(recipeIngredient.Measure.Id);
            return recipeIngredient;    
        }

        public List<RecipeIngredient> RetrieveAll()
        {
            List<RecipeIngredient> recipeIngredients= _repository.RetrieveAll();
            
            foreach ( RecipeIngredient recipeIngredient in recipeIngredients)
            {
                recipeIngredient.Recipe = _recipeService.Retrieve(recipeIngredient.Recipe.Id);
                recipeIngredient.Ingredient = _ingredientService.Retrieve(recipeIngredient.Ingredient.Id);
                recipeIngredient.Measure = _measureService.Retrieve(recipeIngredient.Measure.Id);

            }
            return recipeIngredients;
        }

        public RecipeIngredient Update(RecipeIngredient recipeIngredient)
        {
            return _repository.Update(recipeIngredient);
        }
        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId)
        {
            return _repository.RetrieveAllByRecipeId(recipeId);
        }
        public void DeleteAllByRecipeId(int recipeId)
        {
            _repository.DeleteAllByRecipeId(recipeId);
        }
    }
}
