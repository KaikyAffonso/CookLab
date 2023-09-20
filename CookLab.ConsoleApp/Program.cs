using CookLab.Model;
using CookLab.Repository.Ingredients;
using CookLab.Repository.Users;
using CookLab.Service.Ingredients;
using CookLab.Service.Users;
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


        }
    }
}