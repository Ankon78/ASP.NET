using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, string, User> , IAuth
    {
        BloodDonateEntities2 db;
        internal UserRepo()
        {
            db = new BloodDonateEntities2();
        }
        /*public bool Add(User obj)
        {
           
            throw new NotImplementedException();
        }*/
        public User Add(User obj)
        {
            db.Users.Add(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public User Authenticate(string uname, string pass)
        {
            var user = db.Users.FirstOrDefault(
                u=>
                u.Username.Equals(uname)&
                u.Password.Equals(pass)
                );
            return user;
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            return db.SaveChanges() >0;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<UserRepo> Get()
        {
            throw new NotImplementedException();
        }

        public UserRepo Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserRepo obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }

        User IRepo<User, string, User>.Add(User obj)
        {
            throw new NotImplementedException();
        }

        List<User> IRepo<User, string, User>.Get()
        {
            throw new NotImplementedException();
        }

        User IRepo<User, string, User>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
