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
    public class DealerRatingApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/getRatingByDealerId/{id}")]
        public IEnumerable<DealerRating> getRatingByDealerId(int id)
        {
            DealerRatingController dealerRatingController = ControllerFactory.CreateDealerRatingController();

            return dealerRatingController.getRatingByDealerId(id);
        }

        
        [HttpPost]
        [Route("api/v1/addDealerRating/")]
        public HttpResponseMessage addDealerRating([FromBody] DealerRating value)
        {
            DealerRatingController dealerRatingController = ControllerFactory.CreateDealerRatingController();
            int id = dealerRatingController.addRating(value);

            return Request.CreateResponse(HttpStatusCode.OK, "Dealer ration added successfully. Id-" + id);
        }

            
    }
}
