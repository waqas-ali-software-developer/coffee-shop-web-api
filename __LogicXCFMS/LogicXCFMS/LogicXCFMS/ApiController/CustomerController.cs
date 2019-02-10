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
    /// Customer Controller
    ///</Summary>
    public class CustomerController : ApiController
    {
        private UnitOfWork _unitOfWork;
        ///<Summary>
        /// In controller intialize unit of work
        ///</Summary>
        public CustomerController()
        {
            _unitOfWork = new UnitOfWork(new LogicXDBContext());
        }
        ///<Summary>
        /// This function returns all customer list
        ///</Summary>
        /// <returns>customer list with status of OK </returns>
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            var customers = _unitOfWork.Customer.GetAll().ToList();
            IEnumerable<CustomerModel> listCustomers = Mapper.Map<IEnumerable<Customers>,
                IEnumerable<CustomerModel>>(customers);
            return Request.CreateResponse(HttpStatusCode.OK, listCustomers);
        }
        ///<Summary>
        /// This function return customer info,status code according to id  
        ///</Summary>
        /// <param name ="id">id int parametere</param>
        /// <returns>return company info according to id and status code</returns>
        [HttpGet]
        public HttpResponseMessage GetCustomerById(int id)
        {
            var result = _unitOfWork.Customer.Get(id);
            if (result != null)
            {
                CustomerModel user = Mapper.Map<Customers, CustomerModel>(result);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found at id =" + id);
        }
        ///<Summary>
        /// This function will register customer info and will return message with status code
        ///</Summary>
        /// <param name ="customerDTO">company name string parameter</param>
        /// <returns>return message with status code</returns>
        [HttpPost]
        public HttpResponseMessage RegisterCustomer([FromBody]CustomerDTO customerDTO)
        {
            try
            {
                Customers customer = new Customers();
                customer.first_name = customerDTO.first_name;
                customer.last_name = customerDTO.last_name;
                customer.customer_phone = customerDTO.customer_phone;
                customer.customer_email = customerDTO.customer_email;
                customer.customer_address = customerDTO.customer_address;
                customer.password = customerDTO.password;
                _unitOfWork.Customer.Add(customer);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, "Customer Register");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        ///<Summary>
        /// This function will delete customer from record and return message with status code
        ///</Summary>
        /// <param name ="id">id parameter integer</param>
        /// <returns>return message with status code</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCustomerById(int id)
        {
            try
            {
                var result = _unitOfWork.Customer.Get(id);
                if (result != null)
                {
                    _unitOfWork.Customer.Remove(result);
                    _unitOfWork.Complete();
                    return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted at id =" + id);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not deleted at id =" + id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
 
       
       
    }//end class
}
