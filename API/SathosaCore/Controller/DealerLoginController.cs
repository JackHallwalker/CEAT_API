using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Controller
{
    public interface DealerLoginController
    {
        DealerLogin GetDealerLoginDetails(string username, string password);
        int createDealerLogin(DealerLogin dealerLogin);
    }

    public class DealerLoginControllerImpl : DealerLoginController
    {
        DBConnection dBConnection;
        DealerLoginDAO dealerLoginDAO = DAOFactory.CreateDealerLoginDAO();
        string key = "1prt56";


        public DealerLogin GetDealerLoginDetails(string username, string password)
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerLoginDAO.GetDealerLoginDetails(username, password, dBConnection);
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

        public int createDealerLogin(DealerLogin dealerLogin)
        {
            try
            {
                dBConnection = new DBConnection();

                return dealerLoginDAO.createDealerLogin(dealerLogin, dBConnection);

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
