using CookLab.Model;

namespace CookLab.Service.Ingredients
{
    public interface IIngredientService
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Retrieve(int id);
        List<Ingredient> RetrieveAll();
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
