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
    public class OrderDetailsApiController :ApiController
    {
        [HttpGet]
        [Route("api/v1/GetAllOrderDetailsByCustomerId/{cusId}")]
        public IEnumerable<OrderDetails> GetAllOrderDetailsByCustomerId(int cusId)
        {
            OrderDetailsController orderTypeController = ControllerFactory.CreateOrderDetailsController();

            var orderDetails =  orderTypeController.GetAllOrderDetailsByCustomerId(cusId);
            bool productMaster = true;
            foreach (var orderDetail in orderDetails)
            {
                if (productMaster)
                {
                    var aa = ControllerFactory.CreateProductMasterController();
                    var bb = ControllerFactory.CreateProductLineItemController();
                    orderDetail.productMasters = aa.getProductById(orderDetail.productMasterId);
                    orderDetail.productLineItem = bb.getProductLineItemById(orderDetail.product_line_item_id);
                }
            }

                return orderDetails;
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrdersByCustomerId/{cusId}")]
        public IEnumerable<CustomerOrder> GetAllCustomerOrdersByCustomerId(int cusId)
        {
            CustomerOrderController customerOrderController = ControllerFactory.CreateCustomerOrderController();

            var customerOrders = customerOrderController.GetAllCustomerOrdersByCusID(cusId);
            bool orderDetails = true;
            bool withDealer = true;
            bool productMaster = true;
            bool withFitters = true;
            bool productLineItem = true;
            foreach (var customerOrder in customerOrders)
            {
                if (orderDetails)
                {
                    var aa = ControllerFactory.CreateOrderDetailsController();
                    customerOrder.orderDetails = aa.GetAllOrderDetailsByCustomerOrderId(customerOrder.id);
                }
                if (withDealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    customerOrder.dealer = aa.getDealerById(customerOrder.dealerId);
                }
                if (productMaster)
                {
                    var aa = ControllerFactory.CreateProductMasterController();
                    var bb = ControllerFactory.CreateProductLineItemController();
                    foreach (var orderDetail in customerOrder.orderDetails)
                    {
                        orderDetail.productMasters = aa.getProductById(orderDetail.productMasterId);
                        orderDetail.productLineItem = bb.getProductLineItemById(orderDetail.product_line_item_id);
                    }
                   
                }
                if (withFitters)
                {
                    var aa = ControllerFactory.CreateOrderFitterController();
                    customerOrder.orderFitters = aa.getOrderFittersByCusOrderId(customerOrder.id);
                    var bb = ControllerFactory.CreateFittersController();
                    foreach (var orderFitter in customerOrder.orderFitters)
                    {
                        orderFitter.fitters = bb.getFitterById(orderFitter.fitterId);
                    }
                }

            }
            return customerOrders;
        }

        [HttpPut]
        [Route("api/v1/UpdateOrderDetailStatusByorDeId/{orDeId}/{isReplaced}")]
        public HttpResponseMessage UpdateOrderDetailStatusByorDeId(int orDeId, int isReplaced)
        {
            try
            {
                OrderDetailsController orderTypeController = ControllerFactory.CreateOrderDetailsController();
                int itemId = orderTypeController.UpdateOrderDetailStatusByorDeId(orDeId, isReplaced);
                if (itemId == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Order detail Id not exist.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Ststus Updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/getPreviousBuyingDealersByCustomerid/{cusId}")]
        public IEnumerable<OrderDetailsWithCount> getPreviousBuyingDealersByCustomerid(int cusId)
        {
            OrderDetailsController orderTypeController = ControllerFactory.CreateOrderDetailsController();

            var previousBuyings = orderTypeController.getPreviousBuyingDealersByCustomerid(cusId);

            bool withDealer = true;
            foreach (var previousBuying in previousBuyings)
            {
                if (withDealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    previousBuying.dealer = aa.getDealerById(previousBuying.dealerId);
                }
            }

            return previousBuyings;
        }
    }
}
