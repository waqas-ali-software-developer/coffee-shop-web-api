using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Model.Model
{
    public class UserDTO
    {
      public int  company_id{get;set;}
     public string  user_name {get;set;}
      public string user_phone{get;set;}
      public string user_email{get;set;}
      public string password{get;set;}
      public DateTime user_date_of_joining{get;set;}
    }
    public class UserRoleDTO:UserDTO
    {
        public int role_id { get; set; }
    }
    public class UserModel:UserDTO
    {
        public int user_id { get; set; }
    }
}
