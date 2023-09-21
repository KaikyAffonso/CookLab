using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly string tableName = "posts";
        public Post Create(Post post)
        {
            string sql = $"INSER INTO {tableName} (id_user, id_recipe, comment, rating) VALUES ({post.User.Id}, {post.Recipe.Id}, '{post.Comment}', {post.Rating});";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", tableName);
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id={id};";
            SQL.ExecuteNonQuery(sql);   
        }

        public Post Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"{tableName} de Id: {id} não encontrado.");
        }

        public List<Post> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
            List<Post> posts = new List<Post>();
            while (reader.Read())
            {
                posts.Add(Parse(reader));
            }
            return posts;
        }

        public Post Update(Post post)
        {
            string sql = $"UPDATE {tableName} SET comment= '{post.Comment}', rating= {post.Rating} WHERE id= {post.Id};";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(post.Id);
        }

        private Post Parse(SqlDataReader reader)
        {
            Post post = new Post();
            post.User = new User();
            post.Recipe = new Recipe();
            post.Id = Convert.ToInt32(reader["id"]);
            post.User.Id= Convert.ToInt32(reader["id_user"]);
            post.Recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            post.Comment = Convert.ToString(reader["comment"]);
            post.Rating =Convert.ToInt32(reader["rating"]);

            return post;


        }
    }
}
