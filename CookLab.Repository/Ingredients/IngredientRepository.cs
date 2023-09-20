
using CookLab.Model;
using System.Data.SqlClient;

namespace CookLab.Repository.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string tableName = "ingredients";
        public Ingredient Create(Ingredient ingredient)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{ingredient.Name}');";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
             return Retrieve(id);
            
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);   
        }

        public Ingredient Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
                
            }
            throw new Exception("Ingredient not found.");
        }

        public List<Ingredient> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Ingredient> ingredients = new List<Ingredient>();
            while (reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
            return ingredients;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = $"UPDATE {tableName} SET name = '{ingredient.Name}' WHERE id = {ingredient.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(ingredient.Id);
        }



        private Ingredient Parse(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id"]);
            ingredient.Name = Convert.ToString(reader["name"]);
           
            return ingredient;

        }


    }
}
