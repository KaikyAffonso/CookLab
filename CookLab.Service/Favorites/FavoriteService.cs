using CookLab.Model;
using CookLab.Repository.Favorites;
using CookLab.Repository.Posts;
using CookLab.Service.Recipes;
using CookLab.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Favorites
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repository;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;

        public FavoriteService(IFavoriteRepository repository, IUserService userService, IRecipeService recipeService)
        {
            _repository=repository;
            _userService=userService;
            _recipeService=recipeService;   
        }

        public Favorite Create(Favorite favorite)
        {
            return _repository.Create(favorite);
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public Favorite Retrieve(int id)
        {
            Favorite favorite = _repository.Retrieve(id);
            favorite.User = _userService.Retrieve(favorite.User.Id);
            favorite.Recipe = _recipeService.Retrieve(favorite.Recipe.Id);  
            return favorite;
        }

        public List<Favorite> RetrieveAll()
        {
           List<Favorite> favorites = _repository.RetrieveAll();

            foreach(Favorite favorite in favorites)
            {
                
                favorite.User = _userService.Retrieve(favorite.User.Id);
                favorite.Recipe = _recipeService.Retrieve(favorite.Recipe.Id);

            }
            return favorites;
        }

        public Favorite Update(Favorite favorite)
        {
           return _repository.Update(favorite);  
        }
    }
}
