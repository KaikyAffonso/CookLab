using CookLab.Model;
using CookLab.Repository.Ingredients;
using CookLab.Service.Ingredients;

namespace CookLab.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IngredientRepository repository = new IngredientRepository();
            IIngredientService service = new IngredientService(repository);
            Ingredient ing = new Ingredient();
            ing.Name = "aater";

            service.Create(ing);
        }
    }
}