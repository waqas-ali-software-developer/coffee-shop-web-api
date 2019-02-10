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
    /// User Controller
    ///</Summary>
    public class UsersController : ApiController
    {
        private UnitOfWork _unitOfWork;
        ///<Summary>
        /// In controller intialize unit of work
        ///</Summary>
        public UsersController()
        {
            _unitOfWork = new UnitOfWork(new LogicXDBContext());
        }
        ///<Summary>
        /// This function returns all users list
        ///</Summary>
        /// <returns>users list with status of OK </returns>
        [HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            var users = _unitOfWork.User.GetAll().ToList();
            IEnumerable<UserModel> listUsers = Mapper.Map<IEnumerable<Users>,
                IEnumerable<UserModel>>(users);
            return Request.CreateResponse(HttpStatusCode.OK, listUsers);
        }
        ///<Summary>
        /// This function return user info according to id and status code
        ///</Summary>
        /// <param name ="id">id int parametere</param>
        /// <returns>return user info according to id and status code</returns>
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            var result = _unitOfWork.User.Get(id);
            if (result != null)
            {
                UserModel user = Mapper.Map<Users, UserModel>(result);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found at id =" + id);
        }
        ////<Summary>
        /// This function save user info with role and return message with status code
        ///</Summary>
        /// <param name ="userDTO">userobject as a parameter</param>
        /// <returns>return user info according to id and status code</returns>
        [HttpPost]
        public HttpResponseMessage AddUserWithRole([FromBody]UserRoleDTO userDTO)
        {
            try
            {
                if (_unitOfWork.User.AddUserAndAssingRole(userDTO))
                        return Request.CreateResponse(HttpStatusCode.Created, "User Added");
                else
                    return Request.CreateResponse(HttpStatusCode.NotImplemented, "User not Added");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        ///<Summary>
        /// This function will delete user from record and return message with status code
        ///</Summary>
        /// <param name ="id">id parameter integer</param>
        /// <returns>return message with status code</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteUserById(int id)
        {
            try
            {
                if (_unitOfWork.User.DeleteUserAndRole(id))
                    return Request.CreateResponse(HttpStatusCode.Created, "User Deleted");
                else
                    return Request.CreateResponse(HttpStatusCode.NotImplemented, "User Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        ///<Summary>
        /// This function will update the user info and will return messaage with status code
        ///</Summary>
        /// <param name ="userDTO">This function will take user data transfer object</param>
        /// <returns>return messaage with status code</returns>
        [HttpPut]
        public HttpResponseMessage UpdateUserAndRole(int id, [FromBody]UserRoleDTO userDTO)
        {
            try
            {
                if (_unitOfWork.User.UpdateUserAndRole(id,userDTO))
                    return Request.CreateResponse(HttpStatusCode.Created, "User Updated");
                else
                    return Request.CreateResponse(HttpStatusCode.NotImplemented, "User not Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }//end class
}
