using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CustomerDAO
    {
        int customerCreate(CustomerCreation customer, DBConnection dbConnection);
        int updateCustomer(Customer userLcustomerogin, DBConnection dbConnection);
        int deleteCustomer(int customerID, DBConnection dbConnection);
        List<Customer> GetAllCustomers(DBConnection dbConnection);
        List<Customer> GetAllCustomersByDealerId(int dealerId, DBConnection dbConnection);
        int updateAveRuningRateById(int id, double aveRuningRate, DBConnection dbConnection);
        Customer getCustomerById(int id, DBConnection dbConnection);

    }

    public class CustomerDAOImpl : CustomerDAO
    {
        public int customerCreate(CustomerCreation customer, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO CUSTOMER (MOBILE_NUMBER, NIC, PASSPORT, NAME,ADDRESS, QR_CODE, DEALER_ID,HOME_TOWN, AVERAGE_RUNING_RATE) values('" + customer.mobileNumber + "','" + customer.nic + "','" + customer.passport + "','" + customer.name + "','"+ customer.address+"','"+customer.qrCode+"',"+ customer.dealerId+", '" +customer.homeTown+ "','" + customer.averageRuningRate+"' ) SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateCustomer(Customer customer, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update CUSTOMER set MOBILE_NUMBER = '" + customer.mobileNumber + "', NIC = '" + customer.nic + "', PASSPORT = '" + customer.passport + "', NAME = '" + customer.name + "', ADDRESS = '" + customer.address+ "', QR_CODE = '"+customer.qrCode+ "', DEALER_ID ="+customer.dealerId+ ", HOME_TOWN = '"+customer.homeTown+ "', AVERAGE_RUNING_RATE = '"+customer.averageRuningRate+"' where ID = " + customer.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteCustomer(int customerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE CUSTOMER SET IS_ACTIVE = 0 WHERE ID =" + customerId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Customer> GetAllCustomers(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select* from customer c" +
                                           " inner join customer_login cl on cl.customer_id = c.id" +
                                          " inner join user_login ul on ul.id = cl.user_login_id" +
                                           " where exists" +
                                           " (select 1 from customer_login cl1 where cl1.user_login_id = ul.id)";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Customer>(dbConnection.dr);
        }

        public List<Customer> GetAllCustomersByDealerId(int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM Customer WHERE DEALER_ID =" + dealerId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Customer>(dbConnection.dr);
        }

        public int updateAveRuningRateById(int id, double aveRuningRate, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update CUSTOMER set AVERAGE_RUNING_RATE = '" +aveRuningRate + "'  where ID = " + id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public Customer getCustomerById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Customer>(dbConnection.dr);
        }

    }
}
