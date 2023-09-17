using CookLab.Model;

namespace CookLab.Repository.Measures
{
    public interface IMeasureRepository
    {
        Measure Create (Measure measure);
        Measure Retrieve(int id);
        List<Measure> RetrieveAll();
        Measure Update (Measure measure);      
        void Delete (int id);   

    }
}
