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
    
    public partial class Ref_Order_Status_Code
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ref_Order_Status_Code()
        {
            this.Customer_Orders = new HashSet<Customer_Orders>();
        }
    
        public int order_status_code { get; set; }
        public string order_status_decsription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Orders> Customer_Orders { get; set; }
    }
}
