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
    
    public partial class Messages_Logs
    {
        public int message_log_id { get; set; }
        public int log_type_code { get; set; }
        public string descriptions { get; set; }
    
        public virtual Ref_Logs_Types Ref_Logs_Types { get; set; }
    }
}
