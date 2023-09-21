using CookLab.Model;
using CookLab.Repository.Favorites;
using CookLab.Repository.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Favorites
{
    public class FavoriteService : IFavoriteRepository
    {
        private IFavoriteRepository repository;

        public FavoriteService(IFavoriteRepository repository)
        {
            this.repository=repository;
        }

        public Favorite Create(Favorite favorite)
        {
            return repository.Create(favorite);
        }

        public void Delete(int id)
        {
           repository.Delete(id);
        }

        public Favorite Retrieve(int id)
        {
            return repository.Retrieve(id); 
        }

        public List<Favorite> RetrieveAll()
        {
           return repository.RetrieveAll();
        }

        public Favorite Update(Favorite favorite)
        {
           return repository.Update(favorite);  
        }
    }
}
