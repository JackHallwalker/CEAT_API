using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CeatAPI.Controllers
{
    public class DistrictApiController :ApiController
    {
        [HttpGet]
        [Route("api/v1/GetAllDistrict/")]
        public IEnumerable<District> GetAllDistrict()
        {
            DistrictController orderTypeController = ControllerFactory.CreateDistrictController();

            return orderTypeController.GetAllDistrict();
        }
    }
}
