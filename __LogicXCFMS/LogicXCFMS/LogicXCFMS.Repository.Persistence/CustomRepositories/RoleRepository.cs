using LogicXCFMS.Model;
using LogicXCFMS.Repository.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.Persistence.CustomRepositories
{
    class RoleRepository: Repository<Role>, IRoleRepository
    {
        public RoleRepository(LogicXDBContext context)
            : base(context)
        {
        }
        public LogicXDBContext LogicXDBContext
        {
            get { return Context as LogicXDBContext; }
        }
        public bool DeleteRole(int id)
        {
            return true;
        }

        public bool UpdateRole(int id)
        {
            throw new NotImplementedException();
        }

       

        public bool AddRole(Role role)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Role> GetAllRoles()
        {
            //throw new NotImplementedException();
         //   var auditSchedules = EonDBContext.AuditSchedules.Include(x => x.Department).ToList();
          //  return auditSchedules;
            var roles =this.GetAll();
           // var roles = LogicXDBContext.Roles.ToList();
            return roles;
        }
    }
}
