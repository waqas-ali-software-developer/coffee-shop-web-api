using LogicXCFMS.Repository.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Roles { get; }
        void Update(object entity);
        int Complete();
    }
}
