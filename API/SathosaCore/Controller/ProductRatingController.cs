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
    public interface ProductRatingController
    {
        int addProductRating(ProductRating productRating);
        List<ProductRating> getRatingByProductId(int id);
    }

    public class ProductRatingControllerImpl : ProductRatingController
    {
        DBConnection dBConnection;
        ProductRatingDAO productRatingDAO = DAOFactory.CreateProductRatingDAO();

        public int addProductRating(ProductRating productRating)
        {
            try
            {
                dBConnection = new DBConnection();

                return productRatingDAO.addProductRating(productRating, dBConnection);

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

        public List<ProductRating> getRatingByProductId(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return productRatingDAO.getRatingByProductId(id, dBConnection);
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
