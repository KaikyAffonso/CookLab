using CookLab.Repository.Categories;
using CookLab.Repository.Difficulties;
using CookLab.Repository.Favorites;
using CookLab.Repository.Ingredients;
using CookLab.Repository.Measures;
using CookLab.Repository.Posts;
using CookLab.Repository.Recipes;
using CookLab.Repository.RecipesIngredients;
using CookLab.Repository.Users;
using CookLab.Service.Categories;
using CookLab.Service.Difficulties;
using CookLab.Service.Favorites;
using CookLab.Service.Ingredients;
using CookLab.Service.Measures;
using CookLab.Service.Posts;
using CookLab.Service.Recipes;
using CookLab.Service.RecipesIngredients;
using CookLab.Service.Users;

namespace CookLabWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            builder.Services.AddScoped<IDifficultyRepository, DifficultyRepository>();
            builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            builder.Services.AddScoped<IDifficultyService, DifficultyService>();
            builder.Services.AddScoped<IFavoriteService, FavoriteService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<IMeasureService, MeasureService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();

            builder.Services.AddScoped<IUserService, UserService>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}