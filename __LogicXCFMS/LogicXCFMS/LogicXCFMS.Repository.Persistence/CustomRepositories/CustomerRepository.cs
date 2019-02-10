using LogicXCFMS.Model;
using LogicXCFMS.Repository.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.Persistence.CustomRepositories
{
    class CustomerRepository : Repository<Customers>, ICustomerRepository
    {
        public CustomerRepository(LogicXDBContext context)
            : base(context)
        {
        }
        public LogicXDBContext LogicXDBContext
        {
            get { return Context as LogicXDBContext; }
        }
    }
}
