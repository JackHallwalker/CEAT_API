using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ProductLineItemDAO
    {
        int createProductLineItem(ProductLineItem product, DBConnection dbConnection);
        //int updateProduct(ProductMaster product, DBConnection dbConnection);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<ProductLineItem> GetAllProductLineItems(DBConnection dbConnection);
        ProductLineItem getProductLineItemById(int id, DBConnection dbConnection);
        List<ProductLineItem> GetAllProductLineItemsByRagneOfId(int sId, int eId,DBConnection dbConnection);
        List<ProductLineItemWithDetails> GetAllProductLineItemsByProductMasId(int pMId, DBConnection dbConnection);

    }

    public class ProductLineItemDAOImpl : ProductLineItemDAO
    {
        public int createProductLineItem(ProductLineItem product, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO PRODUCT_LINE_ITEM (PRODUCT_MASTER_ID,NAME, QR_CODE)" +
                "values(" + product.productMasterId + ",'" + product.name + "','" + product.qrCode + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            //return dbConnection.cmd.ExecuteNonQuery();
        }

        //public int updateProduct(ProductMaster product, DBConnection dbConnection)
        //{
        //    dbConnection.cmd.CommandText = "update PRODUCT_MASTER set NAME = '" + product.name + ", DESCRIPTION = '" + product.description + "',WARRANTY_DEACRIPTION = '"+product.warrantyDescription+ "',WARRANTY_DURATION_NUM_OF_MONTH = "+ product.warrantyDurationNumOfMonth+ ", QR_CODE = '"+product.qrCode+"'   where ID = " + product.id ;

        //    return dbConnection.cmd.ExecuteNonQuery();
        //}

        public List<ProductLineItem> GetAllProductLineItems(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_LINE_ITEM ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProductLineItem>(dbConnection.dr);
        }

        public List<ProductLineItemWithDetails> GetAllProductLineItemsByProductMasId(int pMId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = " select pli.*, co.customer_id as customer_Id, co.dealer_id as dealer_Id, co.id as customer_Orders_Id, od.id as order_details_id FROM ceat.dbo.PRODUCT_LINE_ITEM pli" +
                                           " inner join ceat.dbo.order_details od on od.product_line_item_id = pli.id"+
                                           " inner join ceat.dbo.customer_orders co on co.id = od.customer_orders_id"+
                                           " WHERE pli.product_master_id ="+pMId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProductLineItemWithDetails>(dbConnection.dr);
        }

        public List<ProductLineItem> GetAllProductLineItemsByRagneOfId(int sId, int eId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_LINE_ITEM WHERE ID>="+sId+" AND ID<="+eId+"";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProductLineItem>(dbConnection.dr);
        }

        public ProductLineItem getProductLineItemById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_LINE_ITEM WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProductLineItem>(dbConnection.dr);
        }
    }
}
