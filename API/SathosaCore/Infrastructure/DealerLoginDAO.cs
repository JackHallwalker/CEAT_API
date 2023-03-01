using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface DealerLoginDAO
    {
        DealerLogin GetDealerLoginDetails(string username, string password, DBConnection dbConnection);
        int createDealerLogin(DealerLogin dealerLogin, DBConnection dBConnection);
    }

    public class DealerLoginDAOImpl : DealerLoginDAO
    {
        public DealerLogin GetDealerLoginDetails(string username, string password, DBConnection dbConnection)
        {

            dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN UL " +
                                            "INNER JOIN DEALER_LOGIN DL ON UL.ID = DL.USER_LOGIN_ID " +
                                            "WHERE UL.NAME = '" + username + "' AND UL.PASSWORD = '" + password + "' ";
            //int count = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            //return count;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DealerLogin>(dbConnection.dr);
        }

        public int createDealerLogin(DealerLogin dealerLogin, DBConnection dBConnection)
        {
            dBConnection.cmd.CommandText = "INSERT INTO DEALER_LOGIN (USER_LOGIN_ID, DEALER_ID) values (" + dealerLogin.userLoginId + "," + dealerLogin.dealerId + ") SELECT SCOPE_IDENTITY()";
            return dBConnection.cmd.ExecuteNonQuery();
        }

    }
}
