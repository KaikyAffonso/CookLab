using CookLab.Model;
using CookLab.Repository.Categories;
using CookLab.Repository.Difficulties;
using CookLab.Repository.Recipes;
using CookLab.Repository.RecipesIngredients;
using CookLab.Repository.Users;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.RecipesIngredients;
using CookLab.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        
        public RecipeService(IRecipeRepository  recipeRepository, IUserService userService, ICategoryService categoryService, IDifficultyService difficultyService, IRecipeIngredientService recipeIngredientService )
        {
            _repository = recipeRepository;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _recipeIngredientService = recipeIngredientService; 

        }

        public Recipe Create(Recipe recipe)
        {
            return _repository.Create(recipe);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public Recipe Retrieve(int id)
        {
           Recipe recipe = _repository.Retrieve(id);
            
            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
            recipe.Category= _categoryService.Retrieve(recipe.Category.Id);
            recipe.Author = _userService.Retrieve(recipe.Author.Id);
            recipe.Ingredients = _recipeIngredientService.RetrieveAllByRecipeId(recipe.Id);
            recipe.Author.Email="";
            recipe.Author.Password="";
            return recipe;
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();
            foreach(Recipe recipe in recipes) {
                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
                recipe.Category= _categoryService.Retrieve(recipe.Category.Id);
                recipe.Author = _userService.Retrieve(recipe.Author.Id);
                recipe.Author.Email="";
                recipe.Author.Password="";


            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            return _repository.Update(recipe);   
        }
    }
}
