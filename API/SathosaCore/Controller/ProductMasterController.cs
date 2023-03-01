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
    public interface ProductMasterController
    {
        int createProduct(ProductMaster product);
        int updateProduct(ProductMaster product);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<ProductMaster> GetAllProducts();
        ProductMaster getProductById(int id);
    }

    public class ProductMasterControllerImpl : ProductMasterController
    {
        DBConnection DBConnection;
        ProductMasterDAO productMasterDAO = DAOFactory.CreateProductMasterDAO();

        public int createProduct(ProductMaster product)
        {
            try
            {
                DBConnection = new DBConnection();

                return productMasterDAO.createProduct(product, DBConnection);

            }
            catch (Exception)
            {
                DBConnection.RollBack();

                throw;
            }
            finally
            {
                if (DBConnection.con.State == System.Data.ConnectionState.Open)
                    DBConnection.Commit();
            }

        }

        public int updateProduct(ProductMaster product)
        {
            try
            {
                DBConnection = new DBConnection();

                return productMasterDAO.updateProduct(product, DBConnection);

            }
            catch (Exception)
            {
                DBConnection.RollBack();

                throw;
            }
            finally
            {
                if (DBConnection.con.State == System.Data.ConnectionState.Open)
                    DBConnection.Commit();
            }

        }

        public List<ProductMaster> GetAllProducts()
        {
            try
            {
                DBConnection = new DBConnection();
                return productMasterDAO.GetAllProducts(DBConnection);

            }
            catch (Exception)
            {
                DBConnection.RollBack();

                throw;
            }
            finally
            {
                if (DBConnection.con.State == System.Data.ConnectionState.Open)
                    DBConnection.Commit();
            }
        }

        public ProductMaster getProductById(int id)
        {
            try
            {
                DBConnection = new DBConnection();
                return productMasterDAO.getProductById(id, DBConnection);
            }
            catch (Exception)
            {
                DBConnection.RollBack();

                throw;
            }
            finally
            {
                if (DBConnection.con.State == System.Data.ConnectionState.Open)
                    DBConnection.Commit();
            }
        }
    }
}
