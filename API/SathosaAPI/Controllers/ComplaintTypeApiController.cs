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
    public class ComplaintTypeApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/GetAllComplaintTypes/")]
        public IEnumerable<ComplaintType> GetAllComplaintTypes()
        {
            ComplaintTypeController orderTypeController = ControllerFactory.CreateComplaintTypeController();

            return orderTypeController.GetAllComplaintTypes();
        }

        [HttpPost]
        [Route("api/v1/AddComplaintType/")]
        public HttpResponseMessage AddComplaintType([FromBody] ComplaintType value)
        {
            try
            {
                ComplaintTypeController orderTypeController = ControllerFactory.CreateComplaintTypeController();
                int itemId = orderTypeController.AddComplaintType(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Complaint type created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

    }
}
