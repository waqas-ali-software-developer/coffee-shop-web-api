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
    
    public partial class Menus_Products
    {
        public int menu_id { get; set; }
        public int product_id { get; set; }
        public Nullable<System.DateTime> added_date { get; set; }
    
        public virtual Menus Menu { get; set; }
        public virtual Products Product { get; set; }
    }
}