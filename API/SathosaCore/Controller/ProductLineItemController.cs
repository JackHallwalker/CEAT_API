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
    public interface ProductLineItemController
    {
        int createProductLineItem(ProductLineItem product);
        //int updateProduct(ProductMaster product);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<ProductLineItem> GetAllProductLineItems();
        ProductLineItem getProductLineItemById(int id);
        List<ProductLineItem> GetAllProductLineItemsByRagneOfId(int sId, int eId);
        List<ProductLineItemWithDetails> GetAllProductLineItemsByProductMasId(int pMId);

    }

    public class ProductLineItemControllerImpl : ProductLineItemController
    {
        DBConnection DBConnection;
        ProductLineItemDAO productLineItemDAO = DAOFactory.CreateProductLineItemDAO();

        public int createProductLineItem(ProductLineItem product)
        {
            try
            {
                DBConnection = new DBConnection();

                return productLineItemDAO.createProductLineItem(product, DBConnection);

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

        //public int updateProduct(ProductMaster product)
        //{
        //    try
        //    {
        //        DBConnection = new DBConnection();

        //        return productLineItemDAO.updateProduct(product, DBConnection);

        //    }
        //    catch (Exception)
        //    {
        //        DBConnection.RollBack();

        //        throw;
        //    }
        //    finally
        //    {
        //        if (DBConnection.con.State == System.Data.ConnectionState.Open)
        //            DBConnection.Commit();
        //    }

        //}

        public List<ProductLineItem> GetAllProductLineItems()
        {
            try
            {
                DBConnection = new DBConnection();
                return productLineItemDAO.GetAllProductLineItems(DBConnection);

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

        public List<ProductLineItemWithDetails> GetAllProductLineItemsByProductMasId(int pMId)
        {
            try
            {
                DBConnection = new DBConnection();
                return productLineItemDAO.GetAllProductLineItemsByProductMasId(pMId, DBConnection);

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

        public List<ProductLineItem> GetAllProductLineItemsByRagneOfId(int sId, int eId)
        {
            try
            {
                DBConnection = new DBConnection();
                return productLineItemDAO.GetAllProductLineItemsByRagneOfId(sId, eId, DBConnection);

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

        public ProductLineItem getProductLineItemById(int id)
        {
            try
            {
                DBConnection = new DBConnection();
                return productLineItemDAO.getProductLineItemById(id, DBConnection);
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
