using CookLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Users
{
    public interface IUserService
    {
        User Create(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update(User user);
        void Delete(int id);
        User Login(string username, string password);
    }
}
