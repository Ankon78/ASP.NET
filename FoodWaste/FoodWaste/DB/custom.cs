using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWaste.DB
{
    public class custom
    {
        internal int id;

        public User myuser { get; set; }
        public Employee Myemployee { get; set; }
        public Request Myrequest { get; set; }
        public string Food { get; internal set; }
        public int ExpireDate { get; internal set; }
        public string State { get; internal set; }
        public int? AssignEmployee { get; internal set; }
    }
}