using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var db = new List<UserDTO>();
            foreach (var item in UserRepo.Get())
            {
                db.Add(new UserDTO(){ id=item.id , Name=item.Name , Email=item.Email, Contact=item.Contact, Role=item.Role, Password=item.Password});
            }
            return db;
            
        }
    }
}
