//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicXCFMS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders_has_Users
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual Customer_Orders Customer_Orders { get; set; }
        public virtual Users User { get; set; }
    }
}
