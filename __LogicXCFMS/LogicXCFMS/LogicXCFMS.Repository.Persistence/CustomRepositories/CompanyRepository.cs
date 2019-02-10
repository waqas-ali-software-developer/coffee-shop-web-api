using LogicXCFMS.Model;
using LogicXCFMS.Repository.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.Persistence.CustomRepositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(LogicXDBContext context)
            : base(context)
        {
        }
        public LogicXDBContext LogicXDBContext
        {
            get { return Context as LogicXDBContext; }
        }
    }
}
