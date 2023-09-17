
using CookLab.Model;

namespace CookLab.Repository.Categories
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        Category Update(Category category);
        void Delete(int id);
    }
}
