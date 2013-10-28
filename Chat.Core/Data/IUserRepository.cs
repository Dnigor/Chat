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
        User GetUserByName(string name);        
        void AddUser(User user);
        void DeleteUser(string name);
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

        public User GetUserByName(string name) 
        {
            return Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public void AddUser(User user) 
        {           
            Users.Add(user);           
        }

        public void DeleteUser(string name) 
        {
            var user = GetUserByName(name);
          //  Users.Remove(user);
        }
    }
}
