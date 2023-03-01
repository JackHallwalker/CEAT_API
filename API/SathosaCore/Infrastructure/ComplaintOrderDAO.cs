using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ComplaintOrderDAO
    {
        int createComplaintOrder(ComplaintOrder complaintOrder, DBConnection dbConnection);
        int updateComplaintOrder(ComplaintOrder complaintOrder, DBConnection dbConnection);
        int deleteComplaintOrder(int compcomplaintOrderId, DBConnection dbConnection);
        List<ComplaintOrder> GetAllComplaintOrders(DBConnection dbConnection);
        List<ComplaintOrder> GetAllComplaintOrdersByCustomerComplaintId(int CusComId, DBConnection dbConnection);
    }

    public class ComplaintOrderDAOImpl : ComplaintOrderDAO
    {
        public int createComplaintOrder(ComplaintOrder complaintOrder, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "set identity_insert COMPLAINT_ORDERS on;" +
                "INSERT INTO COMPLAINT_ORDERS (ORDER_DETAILS_ID, PRODUCT_MASTER_ID, CUSTOMER_COMPLAINT_ID, REMARK, PRODUCT_LINE_ITEM_ID)" +
                "values(" + complaintOrder.orderDetailsId + "," + complaintOrder.productMasterId + "," + complaintOrder.customerComplaintId + ",'" + complaintOrder.remark + "', "+complaintOrder.product_line_item_id+") ";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateComplaintOrder(ComplaintOrder complaintOrder, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update COMPLAINT_ORDERS set ORDER_DETAILS_ID = " + complaintOrder.orderDetailsId + ", PRODUCT_MASTER_ID = " + complaintOrder.productMasterId + ",CUSTOMER_COMPLAINT_ID = " + complaintOrder.customerComplaintId + ",REMARK = '"+complaintOrder.remark+"', PRODUCT_LINE_ITEM_ID="+complaintOrder.product_line_item_id+"  where ID = " + complaintOrder.customerComplaintId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteComplaintOrder(int complaintOrderId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE COMPLAINT_ORDERS SET IS_RESOLVED = 0 WHERE ID =" + complaintOrderId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ComplaintOrder> GetAllComplaintOrders(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_ORDERS WHERE IS_RESOLVED = 1 ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ComplaintOrder>(dbConnection.dr);
        }

        public List<ComplaintOrder> GetAllComplaintOrdersByCustomerComplaintId(int CusComId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_ORDERS WHERE CUSTOMER_COMPLAINT_ID = " + CusComId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ComplaintOrder>(dbConnection.dr);
        }
    }
}
