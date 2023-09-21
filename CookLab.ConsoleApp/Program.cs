using CookLab.Model;
using CookLab.Repository.Ingredients;
using CookLab.Repository.Recipes;
using CookLab.Repository.Users;
using CookLab.Service.Ingredients;
using CookLab.Service.Recipes;
using CookLab.Service.Users;
using System.Net;
using System.Text.Json;

namespace CookLab.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  TESTE INGREDIENT CREATE() CORRETO!
             * IngredientRepository repository = new IngredientRepository();
             IIngredientService service = new IngredientService(repository);
             Ingredient ing = new Ingredient();
             ing.Name = "feiaaahskssajao"; 
             Ingredient a =   service.Create(ing);
             Console.WriteLine(JsonSerializer.Serialize(a)); */


            /* TESTE USER CREATE() CORRETO!
             * IUserRepository repository = new UserRepository();
             IUserService service = new UserService(repository);

             User user = new User();
             user.Username = "username";
             user.Password = "password";
             user.Email = "email";
             user.Name = "name";
             user.IsBlocked = false;
             user.IsAdmin = true;

             User a = service.Create(user);
             Console.WriteLine(JsonSerializer.Serialize(a));*/

            IRecipeRepository repository = new RecipeRepository();
            IRecipeService service = new RecipeService(repository);

            Recipe recipe = new Recipe();
            recipe.Title = "Test";

            recipe.Author = new User();
            recipe.Author.Id = 1;

            recipe.Category = new Category();
            recipe.Category.Id = 2;

            recipe.PrepTime = 50;

            recipe.PrepMethod = "testetest";


            recipe.Difficulty = new Difficulty();
            recipe.Difficulty.Id = 3;

            recipe.IsApproved = true;

            Recipe a = service.Create(recipe);
            Console.WriteLine(JsonSerializer.Serialize(a));


        }
    }
}