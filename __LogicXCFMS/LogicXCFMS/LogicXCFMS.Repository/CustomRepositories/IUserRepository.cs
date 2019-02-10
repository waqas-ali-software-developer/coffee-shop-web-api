using LogicXCFMS.Model;
using LogicXCFMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.CustomRepositories
{
    public interface IUserRepository:IRepository<Users>
    {
        bool AddUserAndAssingRole(UserRoleDTO userDTO);
        bool UpdateUserAndRole(int id,UserRoleDTO userDTO);

        bool DeleteUserAndRole(int id);
    }//end
}
