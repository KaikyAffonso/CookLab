using CookLab.Model;
using CookLab.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookLab.Service.Users
{
    public class UserService: IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository=repository;
        }

        public User Create(User user)
        {
           return repository.Create(user);  
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public User Retrieve(int id)
        {
            return repository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return repository.RetrieveAll();
        }

        public User Update(User user)
        {
            return repository.Update(user);
        }
    }
}
