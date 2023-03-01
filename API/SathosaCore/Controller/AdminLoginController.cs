using CeatCore.Common;
using CeatCore.Domain;
//using CeatCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

using System.Security.Cryptography;
using CeatCore.Infrastructure;

namespace CeatCore.Controller
{
    public interface AdminLoginController
    {
        AdminLogin GetAdminLoginDetails(string username, string password);
        int createAdminLogin(AdminLogin adminLogin);
        string Encryptword(string Encryptval);

    }

    public class AdminLoginControllerImpl : AdminLoginController
    {
        DBConnection dBConnection;
        AdminLoginDAO adminLoginDAO = DAOFactory.CreateAdminLoginDAO();
        string key = "1prt56";

        public AdminLogin GetAdminLoginDetails(string username, string password)
        {
            try
            {
                dBConnection = new DBConnection();
                return adminLoginDAO.GetAdminLoginDetails(username, password, dBConnection);
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

        public int createAdminLogin(AdminLogin adminLogin)
        {
            try
            {
                dBConnection = new DBConnection();

                return adminLoginDAO.createAdminLogin(adminLogin, dBConnection);

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
