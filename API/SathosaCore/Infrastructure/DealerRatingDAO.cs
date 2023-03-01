using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface DealerRatingDAO
    {
        int addRating(DealerRating dealerRating, DBConnection dbConnection);
        List<DealerRating> getRatingByDealerId(int id, DBConnection dbConnection);
    }

    public class DealerRatingDAOImpl : DealerRatingDAO
    {
        public int addRating(DealerRating dealerRating, DBConnection dbConnection)
        {

            dbConnection.cmd.CommandText = "INSERT INTO DEALER_RATING (CUSTOMER_ORDERS_ID, COMMENT, STAR_COUNT, DEALER_ID) " +
               "values(" + dealerRating.customerOrderId + ",'" + dealerRating.comment + "'," + dealerRating.starCount + ","+dealerRating.dealer_id+") SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<DealerRating> getRatingByDealerId(int id, DBConnection dbConnection)
        {
            //dbConnection.cmd.CommandText = "SELECT * FROM DEALER_RATING DR " +
            //                                "INNER JOIN CUSTOMER_ORDERS CO ON DR.CUSTOMER_ORDERS_ID = CO.ID " +
            //                                " WHERE CO.DEALER_ID = " + id;
            dbConnection.cmd.CommandText = "SELECT * FROM DEALER_RATING WHERE DEALER_ID = " + id;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DealerRating>(dbConnection.dr);
        }
    }
}
