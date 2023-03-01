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
    public class CustomerApiController : ApiController
    {

        [Authorize]
        [HttpPost]
        [Route("api/v1/customerCreate/")]
        public HttpResponseMessage customerCreate([FromBody] CustomerCreation value)
        {
            try
            {
               
                CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
                int itemId = orderTypeController.customerCreate(value);

                UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
                value.userLogin.password = userLoginController.Encryptword(value.password);
                value.userLogin.userId = itemId;
                value.userLogin.userTypeId = 1;
                value.userLogin.name = value.email;
                value.userLogin.companyId = value.companyId;
                int id = userLoginController.createUserLogin(value.userLogin);

                CustomerLoginController aa = ControllerFactory.CreateCustomerLoginController();
                value.customerLogin.customerId = itemId;
                value.customerLogin.userLoginId = id;
                aa.createCustomerLogin(value.customerLogin);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)422, "Unprocessable Entity");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User name or email already exists. Pleace select another value for that fields.");
                //var response = new HttpResponseMessage(HttpStatusCode.Redirect);
                //response.Headers.Location = new Uri("https://www.google.com/");
                //return response;
            }
        }

       

        [HttpGet]
        [Route("api/v1/GetAllCustomers/")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            CustomerController orderTypeController = ControllerFactory.CreateCustomerController();

            return orderTypeController.GetAllCustomers();
        }


        [Authorize]
        [HttpPut]
        [Route("api/v1/updateCustomer/")]
        public HttpResponseMessage updateCustomer([FromBody] Customer value)
        {
            try
            {
                CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
                int itemId = orderTypeController.updateCustomer(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/deleteCustomer/{id}")]
        public HttpResponseMessage deleteCustomer(int id)
        {
            try
            {
                CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
                int itemId = orderTypeController.deleteCustomer(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/updateAveRuningRateById/{cusId}/{aveRunRate}")]
        public HttpResponseMessage updateAveRuningRateById(int cusId, double aveRunRate)
        {
            try
            {
                CustomerController orderTypeController = ControllerFactory.CreateCustomerController();;
                int itemId = orderTypeController.updateAveRuningRateById(cusId, aveRunRate);

                return Request.CreateResponse(HttpStatusCode.OK, "Runing rate Updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomersByDealerId/{dealerId}")]
        public IEnumerable<Customer> GetAllCustomersByDealerId(int dealerId)
        {
            CustomerController orderTypeController = ControllerFactory.CreateCustomerController();

            return orderTypeController.GetAllCustomersByDealerId(dealerId);
        }

        [HttpGet]
        [Route("api/v1/customerHome/{id?}")]
        public Customer getCustomerById(int id)
        {
            CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
            return orderTypeController.getCustomerById(id);
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/customerQrScan/{id?}")]
        public Customer customerQrScan(int id)
        {

            CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
            return orderTypeController.getCustomerById(id);
        }

    }
}
