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
    public class DealerApiController : ApiController
    {
        
        [HttpPost]
        [Route("api/v1/dealerCreate/")]
        public HttpResponseMessage dealerCreate([FromBody] DealerCreation value)
        {
            try
            {
                DealerController orderTypeController = ControllerFactory.CreateDealerController();
                int itemId = orderTypeController.dealerCreate(value);

                UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
                value.userLogin.password = userLoginController.Encryptword(value.password);
                value.userLogin.userId= itemId;
                value.userLogin.userTypeId = 2;
                value.userLogin.name = value.email;
                value.userLogin.companyId = value.companyId;
                int id = userLoginController.createUserLogin(value.userLogin);

                DealerLoginController aa = ControllerFactory.CreateDealerLoginController();
                value.dealerLogin.dealerId = itemId;
                value.dealerLogin.userLoginId = id;
                aa.createDealerLogin(value.dealerLogin);
                
                return Request.CreateResponse(HttpStatusCode.OK, "Dealer created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/v1/GetAllDealers/")]
        public IEnumerable<Dealer> GetAllDealers()
        {
            DealerController orderTypeController = ControllerFactory.CreateDealerController();

            return orderTypeController.GetAllDealers();
        }



        [HttpPut]
        [Route("api/v1/updateDealer/")]
        public HttpResponseMessage updateDealer([FromBody] Dealer value)
        {
            try
            {
                DealerController orderTypeController = ControllerFactory.CreateDealerController();
                int itemId = orderTypeController.updateDealer(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/deleteDealer/{id}")]
        public HttpResponseMessage deleteDealer(int id)
        {
            try
            {
                DealerController orderTypeController = ControllerFactory.CreateDealerController();
                int itemId = orderTypeController.deleteDealer(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/dealerHome/{id?}")]
        public Dealer getDealerById(int id)
        {
            DealerController orderTypeController = ControllerFactory.CreateDealerController();

            return orderTypeController.getDealerById(id);
        }

        [HttpGet]
        [Route("api/v1/getAllDealersByDistrictId/{dealerId}")]
        public IEnumerable<Dealer> getAllDealersByDistrictId(int dealerId)
        {
            DealerController orderTypeController = ControllerFactory.CreateDealerController();

            return orderTypeController.getAllDealersByDistrictId(dealerId);
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/dealerScanQr/{id?}")]
        public Dealer dealerScanQr(int id)
        {
            DealerController orderTypeController = ControllerFactory.CreateDealerController();

            return orderTypeController.getDealerById(id);
        }
    }
}
