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
    public interface DealerRatingController
    {
        int addRating(DealerRating dealerRating);
        List<DealerRating> getRatingByDealerId(int id);
    }

    public class DealerRatingControllerImpl : DealerRatingController
    {
        DBConnection dBConnection;
        DealerRatingDAO dealerRatingDAO = DAOFactory.CreateDealerRatingDAO();

        public int addRating(DealerRating dealerRating)
        {
            try
            {
                dBConnection = new DBConnection();

                return dealerRatingDAO.addRating(dealerRating, dBConnection);

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

        public List<DealerRating> getRatingByDealerId(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerRatingDAO.getRatingByDealerId(id, dBConnection);
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
