

using CookLab.Model;
using System.Data.SqlClient;

namespace CookLab.Repository.Difficulties
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly string tableName = "difficulties";
        public Difficulty Create(Difficulty difficulty)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ({difficulty.Name});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Difficulty Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Ingredient not found.");
        }

        public List<Difficulty> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Difficulty> difficulties = new List<Difficulty>();
            while (reader.Read())
            {
                difficulties.Add(Parse(reader));
            }
            return difficulties;
        }

        public Difficulty Update(Difficulty difficulty)
        {
            string sql = $"UPDATE {tableName} SET name = {difficulty.Name} WHERE id = {difficulty.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(difficulty.Id);
        }
        private Difficulty Parse(SqlDataReader reader)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id"]);
            difficulty.Name = Convert.ToString(reader["name"]);
            return difficulty;
        }
    }
}
