using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo
    {
        public static List<User> Get()
        {
            var db = new MIDEntities();
            return db.Users.ToList();
        }
    }
}
