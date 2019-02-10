using LogicXCFMS.Model;
using LogicXCFMS.Model.Model;
using LogicXCFMS.Repository.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXCFMS.Repository.Persistence.CustomRepositories
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(LogicXDBContext context)
            : base(context)
        {
        }
        public LogicXDBContext LogicXDBContext
        {
            get { return Context as LogicXDBContext; }
        }

        public bool AddUserAndAssingRole(UserRoleDTO userDTO)
        {
            using (var dbContextTransaction = LogicXDBContext.Database.BeginTransaction())
            {
                var flag = false;
                try
                {
                    Users user = new Users();
                    user.user_name = userDTO.user_name;
                    user.user_phone = userDTO.user_phone;
                    user.user_email = userDTO.user_email;
                    user.user_date_of_joining = userDTO.user_date_of_joining;
                    user.password = userDTO.password;
                    user.comany_id = userDTO.company_id;
                    LogicXDBContext.Users.Add(user);
                    LogicXDBContext.SaveChanges();
                    User_Roles userRole = new User_Roles();
                    userRole.role_id = userDTO.role_id;
                    userRole.user_id = user.user_id;
                    userRole.role_assign_date = DateTime.Now;
                    LogicXDBContext.User_Roles.Add(userRole);
                    LogicXDBContext.SaveChanges();
                    dbContextTransaction.Commit();
                    flag = true;

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    flag = false;
                }
                return flag;
            }
        }


        public bool UpdateUserAndRole(int id,UserRoleDTO userDTO)
        {
            using (var dbContextTransaction = LogicXDBContext.Database.BeginTransaction())
            {
                var flag = false;
                try
                {

                    var user = this.Get(id);
                    if (user != null)
                    {
                        user.user_name = userDTO.user_name;
                        user.user_phone = userDTO.user_phone;
                        user.user_email = userDTO.user_email;
                        user.user_date_of_joining = userDTO.user_date_of_joining;
                        user.password = userDTO.password;
                        user.comany_id = userDTO.company_id;
                        LogicXDBContext.Entry(user).State = EntityState.Modified;
                        var oldUserRole = LogicXDBContext.User_Roles.Where(x => x.user_id == id).FirstOrDefault();
                        if (oldUserRole != null)
                        {
                            LogicXDBContext.Entry(oldUserRole).State = EntityState.Deleted;
                            User_Roles userRole = new User_Roles();
                            userRole.role_id = userDTO.role_id;
                            userRole.user_id = user.user_id;
                            userRole.role_assign_date = DateTime.Now;
                            LogicXDBContext.User_Roles.Add(userRole);
                        }
                        LogicXDBContext.SaveChanges();
                        dbContextTransaction.Commit();
                        flag = true;
                    }

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    flag = false;
                }
                return flag;
            }
           
        }

        public bool DeleteUserAndRole(int id)
        {
            using (var dbContextTransaction = LogicXDBContext.Database.BeginTransaction())
            {
                var flag = false;
                try
                {
                    var user = this.Get(id);
                    LogicXDBContext.Entry(user).State = EntityState.Deleted;
                    if (user != null)
                    {
                        var oldUserRole = LogicXDBContext.User_Roles.Where(x => x.user_id == id).FirstOrDefault();
                        if (oldUserRole != null)
                            LogicXDBContext.Entry(oldUserRole).State = EntityState.Deleted;
                        
                        LogicXDBContext.Entry(user).State = EntityState.Deleted;
                        LogicXDBContext.SaveChanges();
                        dbContextTransaction.Commit();
                        flag = true;
                    }

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    flag = false;
                }
                return flag;
            }

        }
     
    }//end class
}
