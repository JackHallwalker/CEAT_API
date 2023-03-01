using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface OrderDetailsDAO
    {
        int createOrderDetails(OrderDetails OrderDetail, DBConnection dbConnection);
        int updateOrderDetails(OrderDetails OrderDetail, DBConnection dbConnection);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<OrderDetails> GetAllOrderDetails(DBConnection dbConnection);
        List<OrderDetails> GetAllOrderDetailsByCustomerId(int cusId, DBConnection dbConnection);
        List<OrderDetails> GetAllOrderDetailsByCustomerOrderId(int cusOrderId, DBConnection dbConnection);
        int UpdateOrderDetailStatusByorDeId(int orDeId, int isReplaced, DBConnection dbConnection);
        bool CheckUserOrderDetailExitsById(int orDeId, DBConnection dbConnection);

        List<OrderDetailsWithCount> getPreviousBuyingDealersByCustomerid(int cusId, DBConnection dbConnection);
        OrderDetails getOrderDetailById(int id, DBConnection dbConnection);
    }

    public class OrderDetailsDAOImpl : OrderDetailsDAO
    {
        public int createOrderDetails(OrderDetails OrderDetail, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO ORDER_DETAILS (PRODUCT_MASTER_ID, CUSTOMER_ORDERS_ID, QUANTITY, WARRANTY_START, WARRANTY_END,IS_REPLACED, PRODUCT_LINE_ITEM_ID )" +
                "values(" + OrderDetail.productMasterId + "," + OrderDetail.customerOrdersId + "," + OrderDetail.quantity + ",'" + OrderDetail.warrantyStart.ToString("yyyy-MM-dd") + "', '" + OrderDetail.warrantyEnd.ToString("yyyy-MM-dd") + "',0, "+OrderDetail.product_line_item_id+") SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateOrderDetails(OrderDetails OrderDetail, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update ORDER_DETAILS set PRODUCT_MASTER_ID = " + OrderDetail.productMasterId + ", QUANTITY = " + OrderDetail.quantity + ", PRODUCT_LINE_ITEM_ID="+OrderDetail.product_line_item_id+"  where ID = " + OrderDetail.id+ " AND CUSTOMER_ORDERS_ID = "+OrderDetail.customerOrdersId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<OrderDetails> GetAllOrderDetails(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ORDER_DETAILS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderDetails>(dbConnection.dr);
        }

        public List<OrderDetails> GetAllOrderDetailsByCustomerId(int cusId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT OD.*, D.NAME AS DEALER_NAME, D.STORE_NAME AS STORE_NAME FROM ORDER_DETAILS OD " +
                                            " INNER JOIN CUSTOMER_ORDERS CO ON OD.CUSTOMER_ORDERS_ID = CO.ID " +
                                            " INNER JOIN DEALER D ON CO.DEALER_ID = D.ID" +
                                            " WHERE CO.CUSTOMER_ID = " + cusId + " ORDER BY CO.ORDER_DATE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderDetails>(dbConnection.dr);
        }

        public int UpdateOrderDetailStatusByorDeId(int orDeId, int isReplaced, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE ORDER_DETAILS SET IS_REPLACED =" + isReplaced + " WHERE ID = " + orDeId + " ";

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public bool CheckUserOrderDetailExitsById(int orDeId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ORDER_DETAILS WHERE ID = " + orDeId + " ";

            return Convert.ToBoolean(dbConnection.cmd.ExecuteNonQuery());
        }

        public List<OrderDetails> GetAllOrderDetailsByCustomerOrderId(int cusOrderId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ORDER_DETAILS OD " +
                                            "WHERE OD.CUSTOMER_ORDERS_ID = " + cusOrderId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderDetails>(dbConnection.dr);
        }

        public List<OrderDetailsWithCount> getPreviousBuyingDealersByCustomerid(int cusId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT CO.DEALER_ID AS DEALER_ID, COUNT(OD.ID) AS COUNT FROM CUSTOMER_ORDERS CO" +
                                            " INNER JOIN ORDER_DETAILS OD ON CO.ID = OD.CUSTOMER_ORDERS_ID" +
                                            " WHERE CO.CUSTOMER_ID = " + cusId +
                                            " GROUP BY CO.DEALER_ID";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderDetailsWithCount>(dbConnection.dr);
        }

        public OrderDetails getOrderDetailById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ORDER_DETAILS WHERE ID= " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<OrderDetails>(dbConnection.dr);
        }
    }
}
