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
    public class ProductRatingApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/getRatingByProductId/{id}")]
        public IEnumerable<ProductRating> getRatingByProductId(int id)
        {
            ProductRatingController orderTypeController = ControllerFactory.CreateProductRatingController();

            var productRating = orderTypeController.getRatingByProductId(id);
            bool productMaster = true;
            bool productLineItem = true;

            foreach (var item in productRating)
            {
                if (productMaster)
                {
                    ProductMasterController aa = ControllerFactory.CreateProductMasterController();
                    item.productMaster = aa.getProductById(item.productMasterId);
                    ProductLineItemController bb = ControllerFactory.CreateProductLineItemController();
                    item.productLineItem = bb.getProductLineItemById(item.productLineItemId);
                }
            }

            return productRating;
        }

        [HttpPost]
        [Route("api/v1/addProductRating/")]
        public HttpResponseMessage addProductRating([FromBody] ProductRating value)
        {
            ProductRatingController productRatingController = ControllerFactory.CreateProductRatingController();
            int id = productRatingController.addProductRating(value);

            return Request.CreateResponse(HttpStatusCode.OK, "Dealer ration added successfully. Id-" + id);
        }

    }
    
}
