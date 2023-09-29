using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string tableName = "users";

        public User Create(User user)
        {
            int isBlocked = user.IsBlocked ? 1 : 0;
            int isAdmin = user.IsAdmin ? 1 : 0;
            string sql = $"INSERT INTO {tableName} (username, password, name, email, is_admin, is_blocked) VALUES ('{user.Username}', CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2), '{user.Name}', '{user.Email}', '{isAdmin}', '{isBlocked}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", tableName);
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM users WHERE id={id}";
            SQL.ExecuteNonQuery(sql);
        }

        public User Retrieve(int id)
        {
            string sql = $"SELECT * FROM users WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"User de Id: {id} não encontrado.");
        }

        public List<User> RetrieveAll()
        {
            string sql = "SELECT * FROM users;";
            SqlDataReader reader = SQL.Execute(sql);
            List<User> user = new List<User>();
            while (reader.Read())
            {
                user.Add(Parse(reader));
            }
            return user;
        }

        public User Update(User user)
        {

            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;
            string sql = $"UPDATE {tableName} SET" +
                $" password = CONVERT(VARCHAR(32), HashBytes('MD5', '{user.Password}'), 2)," +
                $" name = '{user.Name}'," +
                $" email = '{user.Email}'," +
                $" is_admin = '{isAdmin}'," +
                $" is_blocked = '{isBlocked}'," +
                $" WHERE id = {user.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(user.Id);
        }

        private User Parse(SqlDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(reader["id"]);
            user.Username= Convert.ToString(reader["username"]);
            user.Password= Convert.ToString(reader["password"]);
            user.Name= Convert.ToString(reader["name"]);
            user.Email= Convert.ToString(reader["email"]);
            user.IsAdmin= Convert.ToBoolean(reader["is_admin"]);
            user.IsBlocked= Convert.ToBoolean(reader["is_blocked"]);
            return user;
        }
    }

}
