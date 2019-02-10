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
    /// Company Controller
    ///</Summary>
    public class CompanyController : ApiController
    {
        private UnitOfWork _unitOfWork;

        ///<Summary>
        /// In controller intialize unit of work
        ///</Summary>
        public CompanyController()
        {
           _unitOfWork = new UnitOfWork(new LogicXDBContext());
        }
        ///<Summary>
        /// This function returns all companies list
        ///</Summary>
        /// <returns>company list with status of OK </returns>
        [HttpGet]
        public HttpResponseMessage GetAllCompanies()
        {
            var companies = _unitOfWork.Company.GetAll().ToList();
            IEnumerable<CompanyModel> listCompanies = Mapper.Map<IEnumerable<Company>,
                IEnumerable<CompanyModel>>(companies);
            return Request.CreateResponse(HttpStatusCode.OK, listCompanies);
            }
        ///<Summary>
        /// This function return company info according to id and status code
        ///</Summary>
        /// <param name ="id">id int parametere</param>
        /// <returns>return company info according to id and status code</returns>
         [HttpGet]
        public HttpResponseMessage GetCompanyById(int id)
        {
            var result = _unitOfWork.Company.Get(id);
            if (result != null)
            {
                CompanyModel role = Mapper.Map<Company, CompanyModel>(result);
                return Request.CreateResponse(HttpStatusCode.OK, role);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Company not found at id ="+id);
        }
        ///<Summary>
        /// This function will save company name, company details and will return message with status code
        ///</Summary>
         /// <param name ="companyName">company name string parameter</param>
         /// <param name ="companyDetails">company details string parameter</param>
         /// <returns>return message with status code</returns>
        [HttpPost]
         public HttpResponseMessage AddCompany(CompanyDTO companyDTO)
        {
            try
            {
                Company company = new Company();
                company.company_name = companyDTO.company_name;
                company.company_details = companyDTO.company_details;
                _unitOfWork.Company.Add(company);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.Created, "Company Added");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        ///<Summary>
        /// This function will delete company from record and return message with status code
        ///</Summary>
        /// <param name ="id">company id parameter integer for delete company</param>
        /// <returns>return message with status code</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCompanyById(int id)
        {
            var result = _unitOfWork.Company.Get(id);
            if (result != null)
            {
                _unitOfWork.Company.Remove(result);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, "Company deleted at id ="+ id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Company not deleted at id =" + id);
        }
        ///<Summary>
        /// This function will update the company info and will return messaage with status code
        ///</Summary>
        /// <param name ="id">this function will take company id for update</param>
        /// /// <param name ="company">this function will take company object</param>
        /// <returns>return messaage with status code</returns>
        [HttpPut]
        public HttpResponseMessage UpdateCompanyInfo(int id,[FromBody]CompanyDTO company)
        {
            var result = _unitOfWork.Company.Get(id);
            if (result != null)
            {
                result.company_name = company.company_name;
                result.company_details = company.company_details;
                _unitOfWork.Update(result);
                _unitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, "Company updated at id =" + id);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Company not updated at id =" + id);
        }
    }//end class
}
