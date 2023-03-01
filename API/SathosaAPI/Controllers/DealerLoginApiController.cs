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
    public class DealerLoginApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/GetDealerLoginDetails")]
        public DealerLogin GetDealerLoginDetails(string name, string password)
        {
            DealerLoginController userLoginController = ControllerFactory.CreateDealerLoginController();
            //password = userLoginController.Encryptword(password);

            return userLoginController.GetDealerLoginDetails(name, password);
        }

        [HttpPost]
        [Route("api/v1/createDealerLogin/")]
        public HttpResponseMessage createDealerLogin([FromBody] DealerLogin value)
        {
            try
            {
                DealerLoginController orderTypeController = ControllerFactory.CreateDealerLoginController();
                int itemId = orderTypeController.createDealerLogin(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Dealer Login created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

    }
}
