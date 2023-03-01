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
    public class TireTipsApiController : ApiController
    {

        [HttpPost]
        [Route("api/v1/createTireTips/")]
        public HttpResponseMessage createTireTips([FromBody] TireTips value)
        {
            try
            {
                TireTipsController tireTipsController = ControllerFactory.CreateTireTipsController();
                int itemId = tireTipsController.createTireTips(value);

                return Request.CreateResponse(HttpStatusCode.OK, "tire tip created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllTireTips/")]
        public IEnumerable<TireTips> GetAllTireTips()
        {
            TireTipsController tireTipsController = ControllerFactory.CreateTireTipsController();

            return tireTipsController.GetAllTireTips();
        }



        [HttpPut]
        [Route("api/v1/updateTireTips/")]
        public HttpResponseMessage updateTireTips([FromBody] TireTips value)
        {
            try
            {
                TireTipsController tireTipsController = ControllerFactory.CreateTireTipsController();
                int itemId = tireTipsController.updateTireTips(value);

                return Request.CreateResponse(HttpStatusCode.OK, "tire tip updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/v1/deleteTireTips/{id}")]
        public HttpResponseMessage deleteTireTips(int id)
        {
            try
            {
                TireTipsController tireTipsController = ControllerFactory.CreateTireTipsController();
                int itemId = tireTipsController.deleteTireTips(id);

                return Request.CreateResponse(HttpStatusCode.OK, "tire tip deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

    }
}
