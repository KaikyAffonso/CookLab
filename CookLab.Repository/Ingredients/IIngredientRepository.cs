using CookLab.Model;


namespace CookLab.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Retrieve(int id);
        List<Ingredient> RetrieveAll();
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
