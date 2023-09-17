

using CookLab.Model;

namespace CookLab.Repository.Difficulties
{
    public interface IDifficultyRepository
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Retrieve(int id);
        List<Difficulty> RetrieveAll();
        Difficulty Update(Difficulty difficulty);
        void Delete(int id);
    }
}
