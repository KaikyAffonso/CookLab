
using CookLab.Model;
using CookLab.Repository.Categories;

namespace CookLab.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public Category Create(Category category)
        {
            return repository.Create(category);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return repository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
          return repository.RetrieveAll();
        }

        public Category Update(Category category)
        {
           return repository.Update(category);
        }
    }
}
