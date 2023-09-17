

using CookLab.Model;
using CookLab.Repository.Difficulties;

namespace CookLab.Service.Difficulties
{
    public class DifficultyService : IDifficultyService
    {
        private readonly IDifficultyRepository repository;

        public DifficultyService (IDifficultyRepository repository)
        {
            this.repository=repository;
        }

        public Difficulty Create(Difficulty difficulty)
        {
            return repository.Create(difficulty);
        }

        public void Delete(int id)
        {
           repository.Delete(id);
        }

        public Difficulty Retrieve(int id)
        {
            return repository.Retrieve(id);
        }

        public List<Difficulty> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return repository.Update(difficulty);
        }
    }
}
