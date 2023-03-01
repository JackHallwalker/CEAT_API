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
    public class AdminApiController : ApiController
    {

        [Authorize]
        [HttpPost]
        [Route("api/v1/adminCreate/")]
        public HttpResponseMessage adminCreate([FromBody] AdminCreate value)
        {
            try
            {
                AdminController orderTypeController = ControllerFactory.CreateAdminController();
                value.isActive = 1;
                int itemId = orderTypeController.adminCreate(value);

                UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
                value.userLogin.password = userLoginController.Encryptword(value.password);
                value.userLogin.userId = itemId;
                value.userLogin.userTypeId = value.userTypeId;
                value.userLogin.name = value.email;
                value.userLogin.companyId = 1;
                int id = userLoginController.createUserLogin(value.userLogin);

                AdminLoginController aa = ControllerFactory.CreateAdminLoginController();
                value.adminLogin.adminId = itemId;
                value.adminLogin.userLoginId = id;
                aa.createAdminLogin(value.adminLogin);

                return Request.CreateResponse(HttpStatusCode.OK, "Admin created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse((HttpStatusCode)422, "Unprocessable Entity");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User name or email already exists. Pleace select another value for that fields.");
            }
        }

        [HttpGet]
        [Route("api/v1/GetAllAdmins/")]
        public IEnumerable<Admin> GetAllAdmins()
        {
            AdminController orderTypeController = ControllerFactory.CreateAdminController();

            return orderTypeController.GetAllAdmins();
        }


        [Authorize]
        [HttpPut]
        [Route("api/v1/updateAdmin/")]
        public HttpResponseMessage updateAdmin([FromBody] Admin value)
        {
            try
            {
                AdminController orderTypeController = ControllerFactory.CreateAdminController();
                int itemId = orderTypeController.updateAdmin(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Admin updated successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        //[Authorize]
        //[HttpPut]
        //[Route("api/v1/deleteCustomer/{id}")]
        //public HttpResponseMessage deleteCustomer(int id)
        //{
        //    try
        //    {
        //        CustomerController orderTypeController = ControllerFactory.CreateCustomerController();
        //        int itemId = orderTypeController.deleteCustomer(id);

        //        return Request.CreateResponse(HttpStatusCode.OK, "Customer deleted successfully.");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
        //    }
        //}


        [HttpGet]
        [Route("api/v1/adminHome/{id?}")]
        public Admin getAdminById(int id)
        {
            AdminController orderTypeController = ControllerFactory.CreateAdminController();
            return orderTypeController.getAdminById(id);
        }

    }
}
