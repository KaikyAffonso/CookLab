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
      

        private RecipeIngredient Parse(SqlDataReader reader)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Id = Convert.ToInt32(reader["id"]);

            recipeIngredient.Recipe = new Recipe();
            recipeIngredient.Recipe.Id = Convert.ToInt32(reader["id_recipe"]);

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredient"]);
            recipeIngredient.Ingredient = ingredient;

            recipeIngredient.Ingredient = new Ingredient();
            recipeIngredient.Ingredient.Id= Convert.ToInt32(reader["id_ingredient"]);

            recipeIngredient.Measure = new Measure();
            recipeIngredient.Measure.Id= Convert.ToInt32(reader["id_measure"]);
       
            recipeIngredient.quantity= Convert.ToInt64(reader["quantity"]);
            

            return recipeIngredient;


        }
    }
}
