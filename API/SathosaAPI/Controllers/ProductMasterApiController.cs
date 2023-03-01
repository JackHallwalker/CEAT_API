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
    public class ProductMasterApiController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/v1/createProduct/")]
        public HttpResponseMessage createProduct([FromBody] ProductMaster value)
        {
            try
            {
                ProductMasterController orderTypeController = ControllerFactory.CreateProductMasterController();
                int itemId = orderTypeController.createProduct(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Product created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllProducts/")]
        public IEnumerable<ProductMaster> GetAllProducts()
        {
            ProductMasterController orderTypeController = ControllerFactory.CreateProductMasterController();

            return orderTypeController.GetAllProducts();
        }



        [HttpPut]
        [Route("api/v1/updateProduct/")]
        public HttpResponseMessage updateProduct([FromBody] ProductMaster value)
        {
            try
            {
                ProductMasterController orderTypeController = ControllerFactory.CreateProductMasterController();
                int itemId = orderTypeController.updateProduct(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Product updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/v1/getProductById/{id?}")]
        public ProductMaster getProductById(int id)
        {
            ProductMasterController orderTypeController = ControllerFactory.CreateProductMasterController();

            return orderTypeController.getProductById(id);
        }

    }
}
