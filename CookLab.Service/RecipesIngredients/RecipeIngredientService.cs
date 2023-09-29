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
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;


        public RecipeIngredientService(IRecipeIngredientRepository repository, IIngredientService ingredientService,IMeasureService measureService)
        {
            _repository=repository;         
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
            recipeIngredient.Ingredient = _ingredientService.Retrieve(recipeIngredient.Ingredient.Id);
            recipeIngredient.Measure = _measureService.Retrieve(recipeIngredient.Measure.Id);
            return recipeIngredient;    
        }

       

       
        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = _repository.RetrieveAllByRecipeId(recipeId);

            foreach (RecipeIngredient recipeIngredient in recipeIngredients)
            {
               
                recipeIngredient.Ingredient = _ingredientService.Retrieve(recipeIngredient.Ingredient.Id);
                recipeIngredient.Measure = _measureService.Retrieve(recipeIngredient.Measure.Id);

            }
            return recipeIngredients;
        }
        public void DeleteAllByRecipeId(int recipeId)
        {
            _repository.DeleteAllByRecipeId(recipeId);
        }
    }
}
