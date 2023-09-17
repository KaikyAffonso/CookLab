using CookLab.Model;

namespace CookLab.Service.Measures
{
    public interface IMeasureService
    {
        Measure Create(Measure measure);
        Measure Retrieve(int id);
        List<Measure> RetrieveAll();
        Measure Update(Measure measure);
        void Delete(int id);

    }
}
