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
    public class AdminLoginApiController :ApiController
    {
        [HttpGet]
        [Route("api/v1/GetCustomerLoginDetails")]
        public CustomerLogin GetCustomerLoginDetails(string name, string password)
        {
            CustomerLoginController userLoginController = ControllerFactory.CreateCustomerLoginController();
            //password = userLoginController.Encryptword(password);

            return userLoginController.GetCustomerLoginDetails(name, password);
        }

        [HttpPost]
        [Route("api/v1/createCustomerLogin/")]
        public HttpResponseMessage createCustomerLogin([FromBody] CustomerLogin value)
        {
            try
            {
                CustomerLoginController orderTypeController = ControllerFactory.CreateCustomerLoginController();
                int itemId = orderTypeController.createCustomerLogin(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }
    }
}
