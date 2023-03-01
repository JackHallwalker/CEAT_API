using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Controller
{
    public interface UserLoginController
    {
        UserLoginData GetLoginDetails(string name, string password);
        int createUserLogin(UserLogin userLogin);
        UserLogin getEmailByUserId(int userId);

        UserLogin getUserByEmail(string email);
        string Encryptword(string Encryptval);
        void sendEmails(string email);
        int updateUserPasswordByUserId(int userId, string password);

    }


    public class UserLoginControllerImpl : UserLoginController
    {
        DBConnection dBConnection;
        UserLoginDAO userLoginDAO = DAOFactory.CreateUserLoginDAO();
        string key = "1prt56";


        public UserLoginData GetLoginDetails(string name, string password)
        {
            try
            {
                dBConnection = new DBConnection();
                return userLoginDAO.GetLoginDetails(name, password, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
        //public UserLogin GetLoginDetails(string username, string password)
        //{
        //    try
        //    {
        //        dBConnection = new DBConnection();
        //        UserLogin userLogin = new UserLogin();
        //        int user = customerLoginDAO.CheckUserName(username, dBConnection);
        //        //int result = customerLoginDAO.GetLoginDetails(username, password, dBConnection);
        //        if (user == 1)
        //        {
        //            //int result = customerLoginDAO.GetLoginDetails(username, password, dBConnection);
        //            customerLogin = customerLoginDAO.GetLoginDetails(username, password, dBConnection);
        //            //customerLogin.CustomerMobileValidated = CustomerDAO.CustomerMobileValidated(username, dBConnection);

        //            // customerLogin.customer = customerLoginDAO.GettCustmer(customerLogin.customerId, dBConnection);
        //            //     customerLogin.userLogin ==




        //        }
        //        else
        //        {

        //            //customerLogin.Message = "Username or Password is incorrect";
        //        }
        //        customerLogin.Password = "";
        //        return customerLogin;
        //    }
        //    catch (Exception)
        //    {
        //        dBConnection.RollBack();

        //        throw;
        //    }
        //    finally
        //    {
        //        if (dBConnection.con.State == System.Data.ConnectionState.Open)
        //            dBConnection.Commit();
        //    }
        //}



        public string Encryptword(string Encryptval)
        {
            byte[] SrctArray;
            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);
            SrctArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            objcrpt.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateEncryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
            objt.Clear();
            return Convert.ToBase64String(resArray, 0, resArray.Length);
        }
        public int createUserLogin(UserLogin userLogin)
        {
            try
            {
                dBConnection = new DBConnection();

                return userLoginDAO.createUserLogin(userLogin, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public UserLogin getEmailByUserId(int userLoginId)
        {
            try
            {
                dBConnection = new DBConnection();
                return userLoginDAO.getEmailByUserId(userLoginId, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public UserLogin getUserByEmail(string email)
        {
            try
            {
                dBConnection = new DBConnection();
                return userLoginDAO.getUserByEmail(email, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public void sendEmails(string email)
        {
            string title = EmailGenerator.getTitle();


            string emailbody = EmailGenerator.getEmailBody().ToString();

            EmailGenerator.SendEmail(email, title, emailbody, true);

        }

        public int updateUserPasswordByUserId(int userId, string password)
        {
            try
            {
                dBConnection = new DBConnection();
                return userLoginDAO.updateUserPasswordByUserId(userId, password, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}
