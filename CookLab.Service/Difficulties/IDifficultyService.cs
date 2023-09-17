

using CookLab.Model;

namespace CookLab.Service.Difficulties
{
    public interface IDifficultyService
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Retrieve(int id);
        List<Difficulty> RetrieveAll();
        Difficulty Update(Difficulty  difficulty);
        void Delete(int id);
    }
}
