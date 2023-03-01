using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using Microsoft.SqlServer.Server;
using SupremeCourtCore.Controller;
using SupremeCourtCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace CeatAPI.Controllers
{
    public class UserLoginApiController : ApiController
    {
        [HttpGet]
        [Route("api/v1/GetLoginDetails")]
        public UserLoginData GetLoginDetails(string name, string password)
        {
            UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
            password = userLoginController.Encryptword(password);
            var userLoginDetails = userLoginController.GetLoginDetails(name, password);

            if (userLoginDetails.userTypeId == 1)
            {
                CustomerController bb = ControllerFactory.CreateCustomerController();
                userLoginDetails.customer = bb.getCustomerById(userLoginDetails.userId);
            }
            else if (userLoginDetails.userTypeId == 2)
            {
                DealerController bb = ControllerFactory.CreateDealerController();
                userLoginDetails.dealer = bb.getDealerById(userLoginDetails.userId);
            }

            return userLoginDetails;
        }

        [HttpPost]
        [Route("api/v1/createUserLogin/")]
        public HttpResponseMessage createUserLogin([FromBody] UserLogin value)
        {
            try
            {


                if (value.userTypeId == 1)
                {
                    CustomerController bb = ControllerFactory.CreateCustomerController();
                    int id = bb.customerCreate(value.customer);

                    UserLoginController orderTypeController = ControllerFactory.CreateUserLoginController();
                    value.password = orderTypeController.Encryptword(value.password);
                    value.userId = id;
                    int itemId = orderTypeController.createUserLogin(value);

                    CustomerLoginController aa = ControllerFactory.CreateCustomerLoginController();

                    foreach (var customerLogin in value.customerLogin)
                    {
                        customerLogin.customerId = id;
                        customerLogin.userLoginId = itemId;
                        aa.createCustomerLogin(customerLogin);
                    }
                }
                else if (value.userTypeId == 2)
                {
                    DealerController bb = ControllerFactory.CreateDealerController();
                    int id = bb.dealerCreate(value.dealer);

                    UserLoginController orderTypeController = ControllerFactory.CreateUserLoginController();
                    value.password = orderTypeController.Encryptword(value.password);
                    value.userId = id;
                    int itemId = orderTypeController.createUserLogin(value);

                    DealerLoginController aa = ControllerFactory.CreateDealerLoginController();

                    foreach (var dealerLogin in value.dealerLogin)
                    {
                        dealerLogin.dealerId = id;
                        dealerLogin.userLoginId = itemId;
                        aa.createDealerLogin(dealerLogin);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Application created successfully");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPost]
        [Route("api/v1/CodeVerify/")]
        public HttpResponseMessage VerifyCode([FromBody] UserLoginReset value)
        {
            try
            {
                UserLoginResetController userLoginResetController = ControllerFactory.CreateUserLoginResetController();
                UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
                UserLoginReset userLoginReset = userLoginResetController.GetUserLoginReset(value);
                UserLogin userLogin = new UserLogin();
                if (userLoginReset.verificationCode == value.verificationCode)
                {
                    userLogin = userLoginController.getUserByEmail(userLoginReset.email);
                    return Request.CreateResponse(HttpStatusCode.OK, "Code Verified! ( id - " + userLogin.id + " )");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Invalid code provided");
                }



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/getEmailByUserId")]
        public UserLogin getEmailByUserId(int userId)
        {
            UserLoginController orderTypeController = ControllerFactory.CreateUserLoginController();

            return orderTypeController.getEmailByUserId(userId);
        }

        [HttpGet]
        [Route("api/v1/getVerificationCode")]
        public UserLoginReset getVerificationCode(int id)
        {
            UserLoginResetController userLoginResetController = ControllerFactory.CreateUserLoginResetController();


            return userLoginResetController.GetUserLoginResetCheck(id);
        }

        [HttpPut]
        [Route("api/v1/SendResetPaswordLink")]
        public HttpResponseMessage SendResetPaswordLink(int userLoginid)
        {
            try
            {
                UserLogin userLogin = new UserLogin();

                UserLoginController orderTypeController = ControllerFactory.CreateUserLoginController();

                var userLoginDetail = orderTypeController.getEmailByUserId(userLoginid);
                string email = userLoginDetail.name;
                orderTypeController.sendEmails(email);
                return Request.CreateResponse(HttpStatusCode.OK, "Reset password link send successfully. ");

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong");
            }
        }

        [HttpPut]
        [Route("api/v1/updateUserPasswordByUserId/{userLoginId}")]
        public HttpResponseMessage updateUserPasswordByUserId(int userLoginId, string password)
        {
            try
            {
                UserLoginController userLoginController = ControllerFactory.CreateUserLoginController();
                string password1 = userLoginController.Encryptword(password);
                int itemId = userLoginController.updateUserPasswordByUserId(userLoginId, password1);

                return Request.CreateResponse(HttpStatusCode.OK, "User Passwaord Updated Successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/SendResetPaswordCode")]
        public HttpResponseMessage SendResetPaswordCode(string Email)
        {
            try
            {
                UserLogin userLogin = new UserLogin();
                UserLoginReset userLoginReset = new UserLoginReset();
                UserLoginReset userLoginResetCheck = new UserLoginReset();
                UserLoginController orderTypeController = ControllerFactory.CreateUserLoginController();
                UserLoginResetController userLoginResetController = ControllerFactory.CreateUserLoginResetController();

                userLogin = orderTypeController.getUserByEmail(Email);
                Random rand = new Random();

                string code = rand.Next(1000, 10000).ToString();
                userLoginReset.id = userLogin.id;
                userLoginReset.email = userLogin.name;
                userLoginReset.verificationCode = code;
                userLoginResetCheck = userLoginResetController.GetUserLoginResetCheck(userLoginReset.id);
                if (userLoginResetCheck.id == 0)
                {

                    int rs = userLoginResetController.Save(userLoginReset);

                    if (rs != 0)
                    {
                        string emailBody = EmailGenerator.getEmailBodyForResetPassword(code).ToString();
                        EmailGenerator.SendEmail(Email, "Password Reset Code ", emailBody, true);
                        return Request.CreateResponse(HttpStatusCode.OK, "Verification Code send successfully. ");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Wait a moment to get a new code");
                }



            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
        }

    }
}
