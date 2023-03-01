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
    public class FittersApiController : ApiController
    {

        [HttpPost]
        [Route("api/v1/fitterCreate/")]
        public HttpResponseMessage fitterCreate([FromBody] Fitters value)
        {
            try
            {
                FittersController orderTypeController = ControllerFactory.CreateFittersController();
                int itemId = orderTypeController.fitterCreate(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Fitter created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllFitters/")]
        public IEnumerable<Fitters> GetAllFitters()
        {
            FittersController orderTypeController = ControllerFactory.CreateFittersController();

            return orderTypeController.GetAllFitters();
        }



        [HttpPut]
        [Route("api/v1/updateFitter/")]
        public HttpResponseMessage updateFitter([FromBody] Fitters value)
        {
            try
            {
                FittersController orderTypeController = ControllerFactory.CreateFittersController();
                int itemId = orderTypeController.updateFitter(value);

                return Request.CreateResponse(HttpStatusCode.OK, "fitter updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/deleteFitter/{id}")]
        public HttpResponseMessage deleteFitter(int id)
        {
            try
            {
                FittersController orderTypeController = ControllerFactory.CreateFittersController();
                int itemId = orderTypeController.deleteFitter(id);

                return Request.CreateResponse(HttpStatusCode.OK, "fitter deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/getFittersByDealerId/{dealerId}")]
        public IEnumerable<Fitters> getFittersByDealerId(int dealerId)
        {
            FittersController orderTypeController = ControllerFactory.CreateFittersController();

            return orderTypeController.getFittersByDealerId(dealerId);
        }
    }
}
