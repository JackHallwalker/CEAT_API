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
    public class CustomerOrderApiController : ApiController
    {
        [HttpPost]
        [Route("api/v1/createCustomerOrder/")]
        public HttpResponseMessage createCustomerOrder([FromBody] CustomerOrder value)
        {
            try
            {
                CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
                int itemId = orderTypeController.createCustomerOrder(value);

                if (value.orderDetails != null)
                {
                    OrderDetailsController aa = ControllerFactory.CreateOrderDetailsController();
                    foreach (var orderdetail in value.orderDetails)
                    {
                        orderdetail.customerOrdersId = itemId;
                        int id = aa.createOrderDetails(orderdetail);

                        //if(orderdetail.productRating != null)
                        //{
                        //    ProductRatingController productRatingController = ControllerFactory.CreateProductRatingController();
                        //    orderdetail.productRating.orderDetailsId = id;
                        //    productRatingController.addProductRating(orderdetail.productRating);
                        //}
                    }
                }

                if(value.orderFitters != null)
                {
                    OrderFitterController orderFitterController = ControllerFactory.CreateOrderFitterController();
                    foreach (var orderfitter in value.orderFitters)
                    {
                        orderfitter.customerOrdersId = itemId;
                        orderFitterController.addOrderFitter(orderfitter);
                    }
                }

                //if(value.dealerRating != null)
                //{
                //    DealerRatingController dealerRatingController = ControllerFactory.CreateDealerRatingController();
                //    value.dealerRating.customerOrderId = itemId;
                //    value.dealerRating.dealer_id = value.dealerId;
                //    dealerRatingController.addRating(value.dealerRating);
                //}
                

                return Request.CreateResponse(HttpStatusCode.OK, "Application created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/updateCustomerOrder/")]
        public HttpResponseMessage updateCustomerOrder([FromBody] CustomerOrder value)
        {
            try
            {
                CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
                int itemId = orderTypeController.updateCustomerOrder(value);

                if (value.orderDetails != null)
                {
                    OrderDetailsController aa = ControllerFactory.CreateOrderDetailsController();
                    foreach (var orderdetail in value.orderDetails)
                    {
                        orderdetail.customerOrdersId = value.id;
                        aa.updateOrderDetails(orderdetail);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Application updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrders/{withOrderDetails}")]
        public IEnumerable<CustomerOrder> GetAllCustomerOrders(bool withOrderDetails)
        {
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();

            var customerOrders = orderTypeController.GetAllCustomerOrders(withOrderDetails);
            bool productMaster = true;
            bool productLineItem = true;

            foreach (var customerOrder in customerOrders)
            {
                if (withOrderDetails)
                {
                    var aa = ControllerFactory.CreateOrderDetailsController();
                    customerOrder.orderDetails = aa.GetAllOrderDetailsByCustomerOrderId(customerOrder.id);
                }

                if (productMaster)
                {
                    var aa = ControllerFactory.CreateProductMasterController();
                    foreach (var orderDetail in customerOrder.orderDetails)
                    {
                        orderDetail.productMasters = aa.getProductById(orderDetail.productMasterId);
                    }
                }

                if (productLineItem)
                {
                    var aa = ControllerFactory.CreateProductLineItemController();
                    foreach (var orderDetail in customerOrder.orderDetails)
                    {
                        orderDetail.productLineItem = aa.getProductLineItemById(orderDetail.product_line_item_id);
                    }
                }

            }

            return customerOrders;
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrdersByDate/{date}")]
        public List<CustomerOrderDetails> GetAllCustomerOrdersByDate(string date)
        {
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var orderDetails = orderTypeController.GetAllCustomerOrdersByDate(date);
            bool productMater = true;
            bool productLineItem = true;
            foreach (var order in orderDetails)
            {
                //if (productMater)
                //{
                //    var aa = ControllerFactory.CreateProductMasterController();
                //    order.productMasters = aa.getProductById(order.product_master_id);
                //}
                if (productLineItem)
                {
                    var aa = ControllerFactory.CreateProductLineItemController();
                    order.productLineItem = aa.getProductLineItemById(order.product_line_item_id);
                    var bb = ControllerFactory.CreateProductMasterController();
                    order.productLineItem.productMaster = bb.getProductById(order.productLineItem.productMasterId);
                }
            }
            

            return orderDetails;

        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrdersByDealerId/{dealerId}")]
        public List<CustomerOrder> GetAllCustomerOrdersByDealerId(int dealerId)
        {
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var customerOrders = orderTypeController.GetAllCustomerOrdersByDealerId(dealerId);
            bool orderDetail = true;
            foreach (var order in customerOrders)
            {
                if (orderDetail)
                {
                    var aa = ControllerFactory.CreateOrderDetailsController();
                    order.orderDetails = aa.GetAllOrderDetailsByCustomerOrderId(order.id);
                }
            }

            return customerOrders;

        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrdersByDateAndDealerId/{dealerId}")]
        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateAndDealerId(int dealerId)
        {
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            string date = "2022-10-26";
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var orderDetails = orderTypeController.GetAllCustomerOrdersByDateAndDealerId(date, dealerId);
            bool productMater = true;
            bool dealer = true;
            bool productLineItem = true;
            foreach (var order in orderDetails)
            {
                //if (productMater)
                //{
                //    var aa = ControllerFactory.CreateProductMasterController();
                //    order.productMasters = aa.getProductById(order.product_master_id);
                //}
                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    order.dealer = aa.getDealerById(order.dealer_id);
                }
                //if (productLineItem)
                //{
                //    var aa = ControllerFactory.CreateProductLineItemController();
                //    order.productLineItem = aa.getProductLineItemById(order.productline_item_id);
                //}
            }

            return orderDetails;

        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerOrdersByDateRangeAndDealerId/{dealerId}")]
        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateRangeAndDealerId(int dealerId)
        {
            //int year = DateTime.Today.Year;
            //int month = DateTime.Today.Month;
            int year = 2022;
            int month = 10;
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var orderDetails = orderTypeController.GetAllCustomerOrdersByDateRangeAndDealerId(year,month, dealerId);
            bool productMater = true;
            bool dealer = true;
            bool productLineItem = true;

            foreach (var order in orderDetails)
            {
                //if (productMater)
                //{
                //    var aa = ControllerFactory.CreateProductMasterController();
                //    order.productMasters = aa.getProductById(order.product_master_id);
                //}
                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    order.dealer = aa.getDealerById(order.dealer_id);
                }
                //if (productLineItem)
                //{
                //    var aa = ControllerFactory.CreateProductLineItemController();
                //    order.productLineItem = aa.getProductLineItemById(order.productline_item_id);
                //}
            }

            return orderDetails;

        }

        //[HttpGet]
        //[Route("api/v1/GetSalesCountByDealerId/{dealerId}")]
        //public List<CustomerOrderSalesCount> GetSalesCountByDealerId(int dealerId)
        //{
        //    //int year = 2022;
        //    //int month = 10;
        //    //string date = "2022-10-26";
        //    int year = DateTime.Today.Year;
        //    int month = DateTime.Today.Month;
        //    string date = DateTime.Now.ToString("yyyy-MM-dd");
        //    CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
        //    var orderDetails = orderTypeController.GetSalesCountByDealerId(year, month,date,dealerId);          
        //    bool dealer = true;
          

        //    foreach (var order in orderDetails)
        //    {

        //        if (dealer)
        //        {
        //            var aa = ControllerFactory.CreateDealerController();
        //            order.dealer = aa.getDealerById(order.dealerId);
        //        }

        //    }

        //    return orderDetails;

        //}

        [Route("api/v1/GetTodaySalesCountByDealerId/{dealerId}")]
        public List<CustomerOrderSalesCountToday> GetTodaySalesCountByDealerId(int dealerId)
        {
            //int year = 2022;
            //int month = 10;
            //string date = "2022-10-26";
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var orderDetails = orderTypeController.GetTodaySalesCountByDealerId( date, dealerId);
            bool dealer = true;


            foreach (var order in orderDetails)
            {

                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    order.dealer = aa.getDealerById(order.dealerId);
                }

            }

            return orderDetails;

        }


        [Route("api/v1/GetThisMonthSalesCountByDealerId/{dealerId}")]
        public List<CustomerOrderSalesCount> GetThisMonthSalesCountByDealerId(int dealerId)
        {
            //int year = 2022;
            //int month = 10;
            //string date = "2022-10-26";
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            CustomerOrderController orderTypeController = ControllerFactory.CreateCustomerOrderController();
            var orderDetails = orderTypeController.GetThisMonthSalesCountByDealerId(year, month, dealerId);
            bool dealer = true;


            foreach (var order in orderDetails)
            {

                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    order.dealer = aa.getDealerById(order.dealerId);
                }

            }

            return orderDetails;

        }


    }
}
