using CookLab.Model;

using System.Data.SqlClient;


namespace CookLab.Repository.Measures
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly string tableName = "measures";
        public Measure Create(Measure measure)
        {
            string sql =$"INSERT INTO {tableName} (name) VALUES ('{measure.Name}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql =$"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Measure Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id={id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Measure not found.");
        }

        public List<Measure> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Measure> measures = new List<Measure>();
            while (reader.Read())
            {
                measures.Add(Parse(reader));
            }
            return measures;
        }

        public Measure Update(Measure measure)
        {
            string sql = $"UPDATE {tableName} SET name = '{measure.Name}' WHERE id = {measure.Id};";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(measure.Id);
        }

        private Measure Parse(SqlDataReader reader)
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id"]);
            measure.Name = Convert.ToString(reader["name"]);

            return measure; 

        }
    }
}
