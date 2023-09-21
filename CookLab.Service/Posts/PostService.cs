using CookLab.Model;
using CookLab.Repository.Posts;
using CookLab.Repository.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Posts
{
    public class PostService : IPostService
    {
        private IPostRepository repository;

        public PostService(IPostRepository repository)
        {
            this.repository=repository;
        }

        public Post Create(Post post)
        {
           return repository.Create(post);  
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Post Retrieve(int id)
        {
            return repository.Retrieve(id);
        }

        public List<Post> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public Post Update(Post post)
        {
            return repository.Update(post);
        }
    }
}
