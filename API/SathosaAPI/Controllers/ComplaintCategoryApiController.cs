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
    public class ComplaintCategoryApiController :ApiController
    {
        [HttpGet]
        [Route("api/v1/GetAllComplaintCategories/")]
        public IEnumerable<ComplaintCategory> GetAllComplaintCategories()
        {
            ComplaintCategoryController orderTypeController = ControllerFactory.CreateComplaintCategoryController();

            return orderTypeController.GetAllComplaintCategories();
        }

        [HttpPost]
        [Route("api/v1/AddComplaintCategory/")]
        public HttpResponseMessage AddComplaintCategory([FromBody] ComplaintCategory value)
        {
            try
            {
                ComplaintCategoryController orderTypeController = ControllerFactory.CreateComplaintCategoryController();
                int itemId = orderTypeController.AddComplaintCategory(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Complaint Category created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllComplaintCategoriesByComTypeId/{comTypeId}")]
        public IEnumerable<ComplaintCategory> GetAllComplaintCategoriesByComTypeId(int comTypeId)
        {
            ComplaintCategoryController orderTypeController = ControllerFactory.CreateComplaintCategoryController();

            return orderTypeController.GetAllComplaintCategoriesByComTypeId(comTypeId);
        }

    }
}
