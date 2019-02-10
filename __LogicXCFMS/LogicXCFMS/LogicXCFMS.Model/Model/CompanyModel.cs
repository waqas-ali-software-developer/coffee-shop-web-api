using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Model.Model
{
    public class CompanyDTO
    {
        public string company_name { get; set; }
        public string company_details { get; set; }
    }
    public class CompanyModel : CompanyDTO
    {
        public int company_id { get; set; }
        
    }
    
}
