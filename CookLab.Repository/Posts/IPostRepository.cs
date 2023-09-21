using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Repository.Posts
{
    public interface IPostRepository
    {
        Post Create(Post post);
        Post Retrieve(int id);
        List<Post> RetrieveAll();
        Post Update(Post post);
        void Delete(int id);
    }
}
