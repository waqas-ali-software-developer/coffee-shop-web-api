using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Model.Model
{
  
    public class CustomerDTO
    {
          
      public string first_name{get;set;}
      public string last_name{get;set;}
      public string customer_phone {get;set;}
      public string customer_email {get;set;}
      public string customer_address{get;set;}
     public string password{get;set;}
    }
    public class CustomerModel:CustomerDTO
    {
        public int customer_id { get; set; }
    }

 
}
