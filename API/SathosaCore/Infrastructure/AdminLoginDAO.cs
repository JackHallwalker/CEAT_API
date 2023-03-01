using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface AdminLoginDAO
    {
        AdminLogin GetAdminLoginDetails(string username, string password, DBConnection dbConnection);
        int createAdminLogin(AdminLogin adminLogin, DBConnection dBConnection);
    }

    public class AdminLoginDAOImpl :AdminLoginDAO
    {
        public AdminLogin GetAdminLoginDetails(string username, string password, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN UL " +
                                            "INNER JOIN ADMIN_LOGIN AL ON UL.ID = AL.USER_LOGIN_ID " +
                                            "WHERE UL.USER_NAME = '" + username + "' AND UL.PASSWORD = '" + password + "' ";

            //int count = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            //return count;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<AdminLogin>(dbConnection.dr);
        }

        public int createAdminLogin(AdminLogin adminLogin, DBConnection dBConnection)
        {
            dBConnection.cmd.CommandText = "INSERT INTO ADMIN_LOGIN (USER_LOGIN_ID, ADMIN_ID) values (" + adminLogin.userLoginId + "," + adminLogin.adminId + ")";
            //return dBConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dBConnection.cmd.ExecuteScalar());
        }


    }
}
