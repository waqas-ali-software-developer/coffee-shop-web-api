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
    
    public partial class Customer_Payment_Methods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer_Payment_Methods()
        {
            this.Customer_Orders = new HashSet<Customer_Orders>();
        }
    
        public int customer_payment_method_id { get; set; }
        public int customer_id { get; set; }
        public int payment_method_code { get; set; }
        public Nullable<System.DateTime> date_from { get; set; }
        public Nullable<System.DateTime> date_to { get; set; }
        public string other_details { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Orders> Customer_Orders { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Ref_Payment_Methods Ref_Payment_Methods { get; set; }
    }
}
