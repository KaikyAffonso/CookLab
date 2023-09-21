using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.Favorites
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly string tableName = "favorites";
        public Favorite Create(Favorite favorite)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ({favorite.User.Id}, {favorite.Recipe.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Favorite Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Ingredient not found.");
        }

        public List<Favorite> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Favorite> favorites = new List<Favorite>();
            while (reader.Read())
            {
                favorites.Add(Parse(reader));
            }
            return favorites;
        }

        public Favorite Update(Favorite favorite)
        {
            string sql = $"UPDATE {tableName} SET id_user = {favorite.User.Id}, id_recipe= {favorite.Recipe.Id}  WHERE id =  {favorite.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(favorite.Id);
        }

        private Favorite Parse(SqlDataReader reader) {

            Favorite favorite = new Favorite();
            favorite.User = new User();
            favorite.Recipe = new Recipe();
            favorite.User.Id = Convert.ToInt32(reader["id_user"]);
            favorite.Recipe.Id = Convert.ToInt32(reader["id_recipe"]);

            return favorite;    

        }

    }

}
