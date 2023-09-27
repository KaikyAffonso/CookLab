using CookLab.Model;
using CookLab.Repository.Posts;
using CookLab.Repository.Recipes;
using CookLab.Service.Recipes;
using CookLab.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IUserService _userService;
        private readonly IRecipeService _recipeService;


        public PostService(IPostRepository repository, IUserService userService, IRecipeService recipeService)
        {
            _repository=repository;
            _recipeService= recipeService;
            _userService=userService;
        }

        public Post Create(Post post)
        {
           return _repository.Create(post);  
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Post Retrieve(int id)
        {
            Post post=  _repository.Retrieve(id);
            post.User = _userService.Retrieve(post.User.Id);
            post.Recipe = _recipeService.Retrieve(post.Recipe.Id);  
            return post;
        }

        public List<Post> RetrieveAll()
        {
            List<Post> posts= _repository.RetrieveAll();

            foreach(Post post in posts) {
                post.User = _userService.Retrieve(post.User.Id);
                post.Recipe = _recipeService.Retrieve(post.Recipe.Id);
            }
            return posts;   
        }

        public Post Update(Post post)
        {
            return _repository.Update(post);
        }
    }
}
