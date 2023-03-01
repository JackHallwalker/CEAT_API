using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CeatAPI.Controllers
{
    public class CompanyApiController :ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/v1/companyCreate/")]
        public HttpResponseMessage companyCreate([FromBody] Company value)
        {
            try
            {
                CompanyController orderTypeController = ControllerFactory.CreateCompanyController();
                int itemId = orderTypeController.companyCreate(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Company created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/GetAllCompanies/")]
        public IEnumerable<Company> GetAllCompanies()
        {
            CompanyController orderTypeController = ControllerFactory.CreateCompanyController();

            return orderTypeController.GetAllCompanies();
        }


        [Authorize]
        [HttpPut]
        [Route("api/v1/updateCompany/")]
        public HttpResponseMessage updateCompany([FromBody] Company value)
        {
            try
            {
                CompanyController orderTypeController = ControllerFactory.CreateCompanyController();
                int itemId = orderTypeController.updateCompany(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Company updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/v1/deleteCompany/{id}")]
        public HttpResponseMessage deleteCompany(int id)
        {
            try
            {
                CompanyController orderTypeController = ControllerFactory.CreateCompanyController();
                int itemId = orderTypeController.deleteCompany(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Company deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }
    }
}
