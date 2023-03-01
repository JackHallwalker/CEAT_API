using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CustomerOrderDAO
    {
        int createCustomerOrder(CustomerOrder customerOrder, DBConnection dbConnection);
        int updateCustomerOrder(CustomerOrder customerOrder, DBConnection dbConnection);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<CustomerOrder> GetAllCustomerOrders(DBConnection dbConnection);
        List<CustomerOrder> GetAllCustomerOrdersByCusID(int cusId, DBConnection dbConnection);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDate(string date, DBConnection dbConnection);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDateAndDealerId(string date,int dealerId, DBConnection dbConnection);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDateRangeAndDealerId(int year, int month, int dealerId, DBConnection dbConnection);
        List<CustomerOrderSalesCount> GetSalesCountByDealerId(int year, int month,string date, int dealerId, DBConnection dbConnection);
        List<CustomerOrder> GetAllCustomerOrdersByDealerId(int dealerId, DBConnection dbConnection);
        CustomerOrder getCustomerOrderById(int id, DBConnection dbConnection);
        List<CustomerOrderSalesCountToday> GetTodaySalesCountByDealerId( string date, int dealerId, DBConnection dbConnection);
        List<CustomerOrderSalesCount> GetThisMonthSalesCountByDealerId(int year, int month, int dealerId, DBConnection dbConnection);
    }

    public class CustomerOrderDAOImpl : CustomerOrderDAO
    {
        public int createCustomerOrder(CustomerOrder customerOrder, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO CUSTOMER_ORDERS (DEALER_ID, CUSTOMER_ID, ORDER_DATE)" +
                "values(" + customerOrder.dealerId + "," + customerOrder.customerId + ",'" + customerOrder.orderDate.ToString("yyyy-MM-dd") + "') SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateCustomerOrder(CustomerOrder customerOrder, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update CUSTOMER_ORDERS set DEALER_ID = " + customerOrder.dealerId + ", CUSTOMER_ID = " + customerOrder.customerId + ",ORDER_DATE = '" + customerOrder.orderDate.ToString("yyyy-MM-dd") + "'  where ID = " + customerOrder.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        //public int deleteCustomerComplaint(int customerComplaintID, DBConnection dbConnection)
        //{
        //    dbConnection.cmd.CommandText = "UPDATE CUSTOMER_COMPLAINT SET IS_RESOLVED = 0 WHERE ID =" + customerComplaintID;

        //    return dbConnection.cmd.ExecuteNonQuery();
        //}

        public List<CustomerOrder> GetAllCustomerOrders(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_ORDERS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrder>(dbConnection.dr);
        }

        public List<CustomerOrder> GetAllCustomerOrdersByCusID(int cusId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_ORDERS WHERE CUSTOMER_ID = " + cusId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrder>(dbConnection.dr);
        }

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDate(string date, DBConnection dbConnection)
        {
            string dateSql = "";
            if (date != null)
                dateSql = " ORDER_DATE= '" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy") + "' ";
            
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity, od.product_line_item_id as product_line_item_id from customer_orders cuo" +
                                           " inner join order_details od on od.customer_orders_id = cuo.id"+
                                           " inner join product_master pm on od.product_master_id = pm.id"+
                                           " where cuo.order_date= '"+ DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' group by od.product_line_item_id";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderDetails>(dbConnection.dr);
        }

        public List<CustomerOrder> GetAllCustomerOrdersByDealerId(int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_ORDERS WHERE DEALER_ID = " + dealerId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrder>(dbConnection.dr);
        }

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateAndDealerId(string date,int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity, cuo.dealer_id as dealer_id from customer_orders cuo" +
                                           " inner join order_details od on od.customer_orders_id = cuo.id" +
                                           " inner join product_master pm on od.product_master_id = pm.id" +
                                           " where cuo.order_date ='" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' and cuo.dealer_id="+dealerId+" group by cuo.dealer_id";
            
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderDetails>(dbConnection.dr);
        }

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateRangeAndDealerId(int year, int month, int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity, cuo.dealer_id as dealer_id from customer_orders cuo" +
                                           " inner join order_details od on od.customer_orders_id = cuo.id" +
                                           " inner join product_master pm on od.product_master_id = pm.id" +
                                           " where YEAR(cuo.order_date)="+year+" and MONTH(cuo.order_date)="+month+" and cuo.dealer_id=" + dealerId + " group by cuo.dealer_id";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderDetails>(dbConnection.dr);
        }

        public List<CustomerOrderSalesCount> GetSalesCountByDealerId(int year, int month, string date, int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity," +
                                            " (select sum(od.quantity) as monthlySale from customer_orders cuo" +
                                            " inner join order_details od on od.customer_orders_id = cuo.id" +
                                            " where YEAR(cuo.order_date)=" + year + " and MONTH(cuo.order_date)= " + month + " and cuo.dealer_id = " + dealerId + " group by cuo.dealer_id) as monthlySale, cuo.dealer_id from customer_orders cuo" +
                                            " inner join order_details od on od.customer_orders_id = cuo.id" +
                                            " where cuo.order_date = '" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' and cuo.dealer_id = " + dealerId + " group by cuo.dealer_id";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderSalesCount>(dbConnection.dr);
        }

        public CustomerOrder getCustomerOrderById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_ORDERS WHERE ID = " + id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CustomerOrder>(dbConnection.dr);
        }

        public List<CustomerOrderSalesCountToday> GetTodaySalesCountByDealerId(string date, int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity,cuo.dealer_id from customer_orders cuo" +
                                           " inner join order_details od on od.customer_orders_id = cuo.id" +
                                           " where cuo.order_date = '" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' and cuo.dealer_id = " + dealerId + " group by cuo.dealer_id";
            //dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity," +
            //                                " (select sum(od.quantity) as monthlySale from customer_orders cuo" +
            //                                " inner join order_details od on od.customer_orders_id = cuo.id" +
            //                                " where YEAR, cuo.dealer_id from customer_orders cuo" +
            //                                " inner join order_details od on od.customer_orders_id = cuo.id" +
            //                                " where cuo.order_date = '" + DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' and cuo.dealer_id = " + dealerId + " group by cuo.dealer_id";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderSalesCountToday>(dbConnection.dr);
        }

        public List<CustomerOrderSalesCount> GetThisMonthSalesCountByDealerId(int year, int month, int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select sum(od.quantity) as quantity,cuo.dealer_id from customer_orders cuo" +
                                           " inner join order_details od on od.customer_orders_id = cuo.id" +
                                           " where YEAR(cuo.order_date) = " + year + " and MONTH(cuo.order_date)= " + month + " and cuo.dealer_id = " + dealerId + " group by cuo.dealer_id";


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerOrderSalesCount>(dbConnection.dr);
        }
    }
}
