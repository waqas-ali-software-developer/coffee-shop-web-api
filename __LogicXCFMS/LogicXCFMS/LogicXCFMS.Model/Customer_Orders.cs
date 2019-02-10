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
    
    public partial class Customer_Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer_Orders()
        {
            this.Customer_Orders_Products = new HashSet<Customer_Orders_Products>();
            this.Orders_has_Users = new HashSet<Orders_has_Users>();
        }
    
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int customer_payment_method_id { get; set; }
        public int order_status_code { get; set; }
        public Nullable<int> total_order_price { get; set; }
        public Nullable<System.DateTime> date_order_paid { get; set; }
        public string other_order_detials { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Orders_Products> Customer_Orders_Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders_has_Users> Orders_has_Users { get; set; }
        public virtual Customer_Payment_Methods Customer_Payment_Methods { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Ref_Order_Status_Code Ref_Order_Status_Code { get; set; }
    }
}
