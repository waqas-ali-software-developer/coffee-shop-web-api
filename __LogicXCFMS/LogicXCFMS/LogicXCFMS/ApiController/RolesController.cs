using AutoMapper;
using LogicXCFMS.Model;
using LogicXCFMS.Model.Model;
using LogicXCFMS.Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicXCFMS.ApiControllers
{
    ///<Summary>
    /// Roles Controller
    ///</Summary>
    public class RolesController : ApiController
    {
        private UnitOfWork _unitOfWork;
        ///<Summary>
        /// In controller intialize unit of work
        ///</Summary>
        public RolesController()
        {
            _unitOfWork = new UnitOfWork(new LogicXDBContext());
        }
        ///<Summary>
        /// This function returns all roles list
        ///</Summary>
        /// <returns>All roles list and status code of OK </returns>
        [HttpGet]
        public HttpResponseMessage GetAllRoles()
        {
            var roles = _unitOfWork.Roles.GetAll().ToList();
            IEnumerable<RoleModel> listObj = Mapper.Map<IEnumerable<Role>,
                IEnumerable<RoleModel>>(roles);
            return Request.CreateResponse(HttpStatusCode.OK, listObj);
        }
        ///<Summary>
        /// This function return role info ,status code according to id 
        ///</Summary>
        /// <param name ="id">id int parametere</param>
        /// <returns>return role info and status code according to id</returns>
        [HttpGet]
        public HttpResponseMessage GetRoleById(int id)
        {
            var result = _unitOfWork.Roles.Get(id);
            if (result != null)
            {
                RoleModel role = Mapper.Map<Role, RoleModel>(result);
                return Request.CreateResponse(HttpStatusCode.OK, role);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Role not found at id =" + id);
        }
        ///<Summary>
        /// This function will save role name and will return message with status code
        ///</Summary>
        /// <param name ="roleName">role name string parameter</param>
        /// <returns>return message with status code</returns>
        [HttpPost]
        public HttpResponseMessage AddRole(string roleName)
        {
            try
            {
                Role objRole = new Role();
                objRole.role_name = roleName;
                _unitOfWork.Roles.Add(objRole);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, "Role Added");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        ///<Summary>
        /// This function will delete role from record and return message with status code
        ///</Summary>
        /// <param name ="id">id parameter integer</param>
        /// <returns>return message with status code</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteRoleById(int id)
        {
            var result = _unitOfWork.Roles.Get(id);
            if (result != null)
            {
                _unitOfWork.Roles.Remove(result);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, "Role deleted at id =" + id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Role not deleted at id =" + id);
        }
        ///<Summary>
        /// This function will update the role info and will return messaage with status code
        ///</Summary>
        /// <param name ="id">id integer for delete role parameter</param>
        ///  <param name ="roleName">this is parametere</param>
        /// <returns>return messaage with status code</returns>
        [HttpPut]
        public HttpResponseMessage UpdateRoleById(int id, string roleName)
        {
            var result = _unitOfWork.Roles.Get(id);
            if (result != null)
            {
                result.role_name = roleName;
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, "Role updated at id =" + id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Role not updated at id =" + id);
        }
    }//end class
}
