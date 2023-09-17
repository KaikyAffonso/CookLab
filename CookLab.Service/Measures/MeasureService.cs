using CookLab.Model;
using CookLab.Repository.Measures;


namespace CookLab.Service.Measures
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository repository;
        public MeasureService(IMeasureRepository repository)
        {
            this.repository = repository;
        }

        public Measure Create(Measure measure)
        {
          return repository.Create(measure);
        }

        public void Delete(int id)
        {
           repository.Delete(id);
        }

        public Measure Retrieve(int id)
        {
           return repository.Retrieve(id);
        }

        public List<Measure> RetrieveAll()
        {
           return repository.RetrieveAll();
        }

        public Measure Update(Measure measure)
        {
            return repository.Update(measure);
        }
    }
}
