using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string UserFirstName { get; set; }
        public bool IsAdmin { get; set; }
    }
}