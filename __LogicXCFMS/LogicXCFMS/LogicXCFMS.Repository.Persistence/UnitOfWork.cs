using LogicXCFMS.Model;
using LogicXCFMS.Repository.CustomRepositories;
using LogicXCFMS.Repository.Persistence.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LogicXDBContext _context;

        public UnitOfWork(LogicXDBContext context)
        {
            _context = context;
            Roles = new RoleRepository(_context);
            Company = new CompanyRepository(_context);
            User = new UserRepository(_context);
            Customer = new CustomerRepository(_context);
        }
        public IRoleRepository Roles{ get; private set;  }
        public ICompanyRepository Company { get; private set; }
        public IUserRepository User { get; private set; }
        public ICustomerRepository Customer{ get; private set; }

        public void Update(object entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
