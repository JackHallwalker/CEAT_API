using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ProductRatingDAO
    {
        int addProductRating(ProductRating productRating, DBConnection dbConnection);
        List<ProductRating> getRatingByProductId(int id, DBConnection dbConnection);
    }

    public class ProductRatingDAOImpl : ProductRatingDAO
    {
        public int addProductRating(ProductRating productRating, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO PRODUCT_RATING (ORDER_DETAILS_ID, COMMENT_2, STAR_COUNT, PRODUCT_MASTER_ID, PRODUCT_LINE_ITEM_ID) " +
               "values(" + productRating.orderDetailsId + ",'" + productRating.comment + "'," + productRating.starCount + ", "+productRating.productMasterId+", "+productRating.productLineItemId+") SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<ProductRating> getRatingByProductId(int id, DBConnection dbConnection)
        {
            //dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_RATING PR " +
            //                                "INNER JOIN ORDER_DETAILS OD ON PR.ORDER_DETAILS_ID = OD.ID " +
            //                                "WHERE OD.PRODUCT_MASTER_ID =" +id;
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_RATING WHERE PRODUCT_MASTER_ID =" + id;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProductRating>(dbConnection.dr);
        }
    }
}
