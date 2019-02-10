using LogicXCFMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.CustomRepositories
{
    public interface IRoleRepository:IRepository<Role>  
    {
        bool UpdateRole(int id);
        IEnumerable<Role> GetAllRoles();
        bool AddRole(Role role);
        bool DeleteRole(int id);
    }
}
