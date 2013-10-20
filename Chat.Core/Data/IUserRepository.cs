using Chat.Core.Entities;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Chat.Core.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);        
        void AddUser(User user);
        void DeleteUser(Guid id);
    }

    public class CacheRepository : IUserRepository
    {
        public CacheRepository()
        {
            Users = new BlockingCollection<User>();
        }

        BlockingCollection<User> Users 
        {
            get { return HttpRuntime.Cache["users"] as BlockingCollection<User>; }
            set { HttpRuntime.Cache["users"] = value; }        
        }

        public IEnumerable<User> GetUsers() 
        {
            return Users;
        }

        public User GetUserById(Guid id) 
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void AddUser(User user) 
        {           
            Users.Add(user);            
        }

        public void DeleteUser(Guid id) 
        {
            var user = GetUserById(id);
          //  Users.Remove(user);
        }
    }
}
