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
        private static readonly object _syncObj = new object();
        public CacheRepository()
        {
            Users = new List<User>();
        }

        List<User> Users 
        {
            get { return HttpRuntime.Cache["users"] as List<User>; }
            set { HttpRuntime.Cache["users"] = value; }        
        }

        public IEnumerable<User> GetUsers() 
        {
            lock (_syncObj)
            {
                return Users;
            }
        }

        public User GetUserByName(string name) 
        {
            lock (_syncObj)
            {
                return Users.Where(u => u.Name == name).FirstOrDefault();
            }
        }

        public void AddUser(User user) 
        {
            lock (_syncObj)
            {
                Users.Add(user);
            }
        }

        public void DeleteUser(string name) 
        {
            lock (_syncObj)
            {
                var user = GetUserByName(name);
                Users.Remove(user);
            }
        }
    }
}
