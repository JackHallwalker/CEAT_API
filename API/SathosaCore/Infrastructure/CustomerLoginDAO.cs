using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CustomerLoginDAO
    {
        CustomerLogin GetCustomerLoginDetails(string username, string password, DBConnection dbConnection);
        int createCustomerLogin(CustomerLogin customerLogin, DBConnection dBConnection);
    }

    public class CustomerLoginDAOImpl : CustomerLoginDAO
    {
        public CustomerLogin GetCustomerLoginDetails(string username, string password, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN UL " +
                                            "INNER JOIN CUSTOMER_LOGIN CL ON UL.ID = CL.USER_LOGIN_ID " +
                                            "WHERE UL.USER_NAME = '" + username + "' AND UL.PASSWORD = '" + password + "' ";

            //int count = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            //return count;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CustomerLogin>(dbConnection.dr);
        }

        public int createCustomerLogin(CustomerLogin customerLogin, DBConnection dBConnection)
        {
            dBConnection.cmd.CommandText = "INSERT INTO CUSTOMER_LOGIN (USER_LOGIN_ID, CUSTOMER_ID) values (" + customerLogin.userLoginId + "," + customerLogin.customerId + ")";
            //return dBConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dBConnection.cmd.ExecuteScalar());
        }


    }
}
