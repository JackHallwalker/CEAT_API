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
    public class ProductLineItemApiController : ApiController
    {
        //[Authorize]
        [HttpPost]
        [Route("api/v1/createProductLineItem/")]
        public HttpResponseMessage createProductLineItem([FromBody] ProductLineItem value)
        {
            try
            {
                ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
                int itemId = orderTypeController.createProductLineItem(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Product line item created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllProductLineItems/")]
        public IEnumerable<ProductLineItem> GetAllProductLineItems()
        {
            ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
            var productLineItems = orderTypeController.GetAllProductLineItems();

            bool productMaster = true;
            foreach (var productLineItem in productLineItems)
            {
                if (productMaster)
                {
                    ProductMasterController aa = ControllerFactory.CreateProductMasterController();
                    productLineItem.productMaster = aa.getProductById(productLineItem.productMasterId);
                }
            }
            return productLineItems;
        }



        //[HttpPut]
        //[Route("api/v1/updateProduct/")]
        //public HttpResponseMessage updateProduct([FromBody] ProductMaster value)
        //{
        //    try
        //    {
        //        ProductMasterController orderTypeController = ControllerFactory.CreateProductMasterController();
        //        int itemId = orderTypeController.updateProduct(value);

        //        return Request.CreateResponse(HttpStatusCode.OK, "Product updated successfully.");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
        //    }
        //}


        [HttpGet]
        [Route("api/v1/getProductLineItemById/{id?}")]
        public ProductLineItem getProductLineItemById(int id)
        {
            ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
            var productLineItems = orderTypeController.getProductLineItemById(id);
            bool productMaster = true;
            if (productMaster)
            {
                ProductMasterController aa = ControllerFactory.CreateProductMasterController();
                productLineItems.productMaster = aa.getProductById(productLineItems.productMasterId);
            }

            return productLineItems;
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/productLineItemQrScan/{id?}")]
        public ProductLineItem productLineItemQrScan(int id)
        {
            ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
            var productLineItems = orderTypeController.getProductLineItemById(id);
            bool productMaster = true;
            if (productMaster)
            {
                ProductMasterController aa = ControllerFactory.CreateProductMasterController();
                productLineItems.productMaster = aa.getProductById(productLineItems.productMasterId);
            }

            return productLineItems;
        }

        [HttpGet]
        [Route("api/v1/GetAllProductLineItemsByProductMasId/")]
        public IEnumerable<ProductLineItemWithDetails> GetAllProductLineItemsByProductMasId(int pMId)
        {
            ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
            var productLineItems = orderTypeController.GetAllProductLineItemsByProductMasId(pMId);

            bool productMaster = true;
            bool customer = true;
            bool dealer = true;
            bool customerOrder = true;
            bool orderDetails = true;
            foreach (var productLineItem in productLineItems)
            {
                if (productMaster)
                {
                    ProductMasterController aa = ControllerFactory.CreateProductMasterController();
                    productLineItem.productMaster = aa.getProductById(productLineItem.productMasterId);
                }

                if (customer)
                {
                    CustomerController customerController = ControllerFactory.CreateCustomerController();
                    productLineItem.customer = customerController.getCustomerById(productLineItem.customer_Id);
                }

                if (dealer)
                {
                    DealerController aa = ControllerFactory.CreateDealerController();
                    productLineItem.dealer = aa.getDealerById(productLineItem.dealer_Id);
                }

                if (customerOrder)
                {
                    CustomerOrderController aa = ControllerFactory.CreateCustomerOrderController();
                    productLineItem.customerOrder = aa.getCustomerOrderById(productLineItem.customer_orders_id);
                }

                if (customerOrder)
                {
                    OrderDetailsController aa = ControllerFactory.CreateOrderDetailsController();
                    productLineItem.orderDetail = aa.getOrderDetailById(productLineItem.order_details_id);
                }
            }
            return productLineItems;
        }

        [HttpGet]
        [Route("api/v1/QrGenerate/")]
        public IEnumerable<ProductLineItem> QrGenerate(int productMastterId, int count)
        {
            ProductLineItemController orderTypeController = ControllerFactory.CreateProductLineItemController();
            int[] LineItemId = new int[count];
            for (int i = 0; i < count; i++)
            {
                var value = new ProductLineItem();
                value.productMasterId = productMastterId;
                value.name = "";
                value.qrCode = "";
                int itemId = orderTypeController.createProductLineItem(value);
                LineItemId[i] = itemId;
            }
            
            return orderTypeController.GetAllProductLineItemsByRagneOfId(LineItemId[0], LineItemId[count-1]); 
        }

    }
}
