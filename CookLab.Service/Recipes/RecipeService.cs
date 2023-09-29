using CookLab.Model;
using CookLab.Repository.Recipes;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Ingredients;
using CookLab.Service.RecipesIngredients;
using CookLab.Service.Users;

namespace CookLab.Service.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDifficultyService _difficultyService;
        private readonly IIngredientService _ingredientService;
        private readonly IRecipeIngredientService _recipeIngredientService;
       
        
        public RecipeService(IRecipeRepository  recipeRepository, IUserService userService, IRecipeIngredientService recipeIngredientService, ICategoryService categoryService, IDifficultyService difficultyService, IIngredientService ingredientService)
        {
            _repository = recipeRepository;
            _userService = userService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _ingredientService = ingredientService;
            _recipeIngredientService= recipeIngredientService;
          
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
            
            recipe.Ingredient = _recipeIngredientService.RetrieveAllByRecipeId(recipe.Id);
            recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
            recipe.Category= _categoryService.Retrieve(recipe.Category.Id);
            recipe.Author = _userService.Retrieve(recipe.Author.Id);          
            recipe.Author.Email="";
            recipe.Author.Password="";
            return recipe;
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();
         
            foreach (Recipe recipe in recipes) {
                
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
