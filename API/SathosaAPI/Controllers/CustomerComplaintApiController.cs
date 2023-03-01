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
    public class CustomerComplaintApiController :ApiController
    {
        [HttpPost]
        [Route("api/v1/createCustomerComplaint/")]
        public HttpResponseMessage createCustomerComplaint([FromBody] CustomerComplaint value)
        {
            try
            {
                CustomerComplaintController customerComplaintController = ControllerFactory.CreateCustomerComplaintController();
                int itemId = customerComplaintController.createCustomerComplaint(value);

                if(value.complaintTypeId == 1)
                {
                    ComplaintOrderController complaintOrderController = ControllerFactory.CreateComplaintOrderController();
                    value.complaintOrder.customerComplaintId = itemId;
                    complaintOrderController.createComplaintOrder(value.complaintOrder);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Customer complaint created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        

        [HttpGet]
        [Route("api/v1/GetAllCustomerComplaints/")]
        public IEnumerable<CustomerComplaintDetails> GetAllCustomerComplaints()
        {
            CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
            var customerComplaints = orderTypeController.GetAllCustomerComplaints();
            bool orderComplaint = true;
            bool dealer = true;
            bool customer = true;
            bool productdetsil = true;
            bool complaintCategory = true;
            foreach (var customerComplaint in customerComplaints)
            {
                if (orderComplaint)
                {
                    var aa = ControllerFactory.CreateComplaintOrderController();
                    customerComplaint.complaintOrders = aa.GetAllComplaintOrdersByCustomerComplaintId(customerComplaint.id);
                    foreach (var product in customerComplaint.complaintOrders)
                    {
                        var bb = ControllerFactory.CreateProductMasterController();
                        product.productMaster = bb.getProductById(product.productMasterId);
                        var cc = ControllerFactory.CreateProductLineItemController();
                        product.productLineItem = cc.getProductLineItemById(product.product_line_item_id);
                    }
                }
                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    customerComplaint.dealer = aa.getDealerById(customerComplaint.dealerId);
                }
                if (complaintCategory)
                {
                    var aa = ControllerFactory.CreateComplaintCategoryController();
                    customerComplaint.complaintCategory = aa.GetComplaintCategoriesByComCatId(customerComplaint.complaintCategoryId);
                }
                if (customer)
                {
                    var aa = ControllerFactory.CreateCustomerController();
                    customerComplaint.customer = aa.getCustomerById(customerComplaint.customerId);
                }
            }
            return customerComplaints;
        }



        [HttpPut]
        [Route("api/v1/updateCustomerComplaint/")]
        public HttpResponseMessage updateCustomerComplaint([FromBody] CustomerComplaint value)
        {
            try
            {
                CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
                int itemId = orderTypeController.updateCustomerComplaint(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer complaint updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/deleteCustomerComplaint/{id}")]
        public HttpResponseMessage deleteCustomerComplaint(int id)
        {
            try
            {
                CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
                int itemId = orderTypeController.deleteCustomerComplaint(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer complaint deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/updateCustomerComplaintAssaignee/")]
        public HttpResponseMessage updateCustomerComplaintAssaignee(int id, int assaigneeId)
        {
            try
            {
                CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
                int itemId = orderTypeController.updateCustomerComplaintAssaignee(id, assaigneeId);

                return Request.CreateResponse(HttpStatusCode.OK, "Assaignee added successfully to complaint.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerComplaintsByAssaignee/{assaigneeId}")]
        public IEnumerable<CustomerComplaint> GetAllCustomerComplaintsByAssaignee(int assaigneeId)
        {
            CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
            var customerComplaints = orderTypeController.GetAllCustomerComplaintsByAssaignee(assaigneeId);
            bool orderComplaint = true;
            bool dealer = true;
            bool customer = true;
            bool productdetsil = true;
            bool complaintCategory = true;
            foreach (var customerComplaint in customerComplaints)
            {
                if (orderComplaint)
                {
                    var aa = ControllerFactory.CreateComplaintOrderController();
                    customerComplaint.complaintOrders = aa.GetAllComplaintOrdersByCustomerComplaintId(customerComplaint.id);
                    foreach (var product in customerComplaint.complaintOrders)
                    {
                        var bb = ControllerFactory.CreateProductMasterController();
                        product.productMaster = bb.getProductById(product.productMasterId);
                        var cc = ControllerFactory.CreateProductLineItemController();
                        product.productLineItem = cc.getProductLineItemById(product.product_line_item_id);
                    }
                }
                if (customer)
                {
                    var aa = ControllerFactory.CreateCustomerController();
                    customerComplaint.customer = aa.getCustomerById(customerComplaint.customerId);
                }
                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    customerComplaint.dealer = aa.getDealerById(customerComplaint.dealerId);
                }
                if (complaintCategory)
                {
                    var aa = ControllerFactory.CreateComplaintCategoryController();
                    customerComplaint.complaintCategory = aa.GetComplaintCategoriesByComCatId(customerComplaint.complaintCategoryId);
                }
            }
            return customerComplaints;
        }

        [HttpPut]
        [Route("api/v1/updateCustomerComplaintByAssaignee/")]
        public HttpResponseMessage updateCustomerComplaintByAssaignee([FromBody] CustomerComplaint value)
        {
            try
            {
                CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
                int itemId = orderTypeController.updateCustomerComplaintByAssaignee(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Customer complaint updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllCustomerComplaintsByCustomerId/{cusId}")]
        public IEnumerable<CustomerComplaint> GetAllCustomerComplaintsByCustomerId(int cusId)
        {
            CustomerComplaintController orderTypeController = ControllerFactory.CreateCustomerComplaintController();
            var customerComplaints = orderTypeController.GetAllCustomerComplaintsByCustomerId(cusId);
            bool orderComplaint = true;
            bool dealer = true;
            bool customer = true;
            bool productdetsil = true;
            bool complaintCategory = true;
            foreach (var customerComplaint in customerComplaints)
            {
                if (orderComplaint)
                {
                    var aa = ControllerFactory.CreateComplaintOrderController();
                    customerComplaint.complaintOrders = aa.GetAllComplaintOrdersByCustomerComplaintId(customerComplaint.id);
                    foreach (var product in customerComplaint.complaintOrders)
                    {
                        var bb = ControllerFactory.CreateProductMasterController();
                        product.productMaster = bb.getProductById(product.productMasterId);
                        var cc = ControllerFactory.CreateProductLineItemController();
                        product.productLineItem = cc.getProductLineItemById(product.product_line_item_id);
                    }
                }
               
                if (dealer)
                {
                    var aa = ControllerFactory.CreateDealerController();
                    customerComplaint.dealer = aa.getDealerById(customerComplaint.dealerId);
                }
                if (customer)
                {
                    var aa = ControllerFactory.CreateCustomerController();
                    customerComplaint.customer = aa.getCustomerById(cusId);
                }
                if (complaintCategory)
                {
                    var aa = ControllerFactory.CreateComplaintCategoryController();
                    customerComplaint.complaintCategory = aa.GetComplaintCategoriesByComCatId(customerComplaint.complaintCategoryId);
                }
            }
            return customerComplaints;
        }


    }
}
