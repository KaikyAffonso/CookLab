using CookLab.Model;
using CookLab.Repository.Ingredients;

namespace CookLab.Service.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository repository;

        public IngredientService(IIngredientRepository repository)
        {
            this.repository = repository;
        }



        public Ingredient Create(Ingredient ingredient)
        {
          return repository.Create(ingredient);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
           return repository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return repository.Update(ingredient);
        }
    }
}
