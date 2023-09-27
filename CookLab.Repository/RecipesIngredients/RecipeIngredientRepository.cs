using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.RecipesIngredients
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly string tableName = "recipe_ingredients";
        public RecipeIngredient Create(RecipeIngredient recipeIngredient)
        {
            string sql = $"INSERT INTO {tableName} (id_recipe, id_ingredient, quantity, id_measure) VALUES ({recipeIngredient.Recipe.Id}, {recipeIngredient.Ingredient.Id}, {recipeIngredient.quantity}, {recipeIngredient.Measure.Id});";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("id", tableName);
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE * FROM recipe_ingredients WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            string sql = $"DELETE FROM {tableName} WHERE id_recipe={recipeId};"; 
        }

        public RecipeIngredient Retrieve(int id)
        {
            string sql = $"SELECT * FROM recipe_ingredients WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if(reader.Read())
            {
                return Parse(reader);

            }
            throw new KeyNotFoundException($"Ingredient de Id: {id} não encontrado.");
        }

        public List<RecipeIngredient> RetrieveAll()
        {
            string sql = "SELECT * FROM recipe_ingredients;";
            SqlDataReader reader = SQL.Execute(sql);
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            while (reader.Read())
            {
                recipeIngredients.Add(Parse(reader));
            }
            return recipeIngredients;
        }
        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId) {

            string sql = $"SELECT * FROM {tableName} WHERE id_recipe= {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
            while(reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
        return ingredients;
        }
        public RecipeIngredient Update(RecipeIngredient recipeIngredient)
        {
            string sql = $"UPDATE recipe_ingredients SET quantity = {recipeIngredient.quantity} WHERE id={recipeIngredient.Id};";
            SQL.ExecuteNonQuery (sql);
            return Retrieve(recipeIngredient.Id);
        }

        private RecipeIngredient Parse(SqlDataReader reader)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Recipe = new Recipe();
            recipeIngredient.Ingredient = new Ingredient();
            recipeIngredient.Measure = new Measure();
            recipeIngredient.Id = Convert.ToInt32(reader["id"]);
            recipeIngredient.Recipe.Id= Convert.ToInt32(reader["id_recipe"]);
            recipeIngredient.Ingredient.Id= Convert.ToInt32(reader["id_ingredient"]);
            recipeIngredient.quantity= Convert.ToDecimal(reader["quantity"]);
            recipeIngredient.Measure.Id= Convert.ToInt32(reader["id_measure"]);

            return recipeIngredient;


        }
    }
}
