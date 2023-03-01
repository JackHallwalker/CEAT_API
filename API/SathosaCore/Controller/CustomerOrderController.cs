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
    public interface CustomerOrderController
    {
        int createCustomerOrder(CustomerOrder customerOrder);
        int updateCustomerOrder(CustomerOrder customerOrder);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<CustomerOrder> GetAllCustomerOrders(bool withOrderDetails);
        List<CustomerOrder> GetAllCustomerOrdersByCusID(int cusId);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDate(string date);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDateAndDealerId(string date, int dealerId);
        List<CustomerOrderDetails> GetAllCustomerOrdersByDateRangeAndDealerId(int year, int month, int dealerId);
        List<CustomerOrderSalesCount> GetSalesCountByDealerId(int year, int month, string date, int dealerId);
        List<CustomerOrder> GetAllCustomerOrdersByDealerId(int dealerId);
        CustomerOrder getCustomerOrderById(int id);
        List<CustomerOrderSalesCountToday> GetTodaySalesCountByDealerId(string date, int dealerId);
        List<CustomerOrderSalesCount> GetThisMonthSalesCountByDealerId(int year, int month, int dealerId);

    }

    public class CustomerOrderControllerImpl : CustomerOrderController
    {
        DBConnection DBConnection;
        CustomerOrderDAO customerOrderDAO = DAOFactory.CreateCustomerOrderDAO();

        public int createCustomerOrder(CustomerOrder customerOrder)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerOrderDAO.createCustomerOrder(customerOrder, DBConnection);

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

        public int updateCustomerOrder(CustomerOrder customerOrder)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerOrderDAO.updateCustomerOrder(customerOrder, DBConnection);

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

        public List<CustomerOrder> GetAllCustomerOrders(bool withOrderDetails)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrders(DBConnection);

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

        public List<CustomerOrder> GetAllCustomerOrdersByCusID(int cusId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrdersByCusID(cusId, DBConnection);

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

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDate(string date)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrdersByDate(date, DBConnection);

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

        public List<CustomerOrder> GetAllCustomerOrdersByDealerId(int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrdersByDealerId(dealerId, DBConnection);

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

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateAndDealerId(string date, int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrdersByDateAndDealerId(date,dealerId, DBConnection);

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

        public List<CustomerOrderDetails> GetAllCustomerOrdersByDateRangeAndDealerId(int year, int month, int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetAllCustomerOrdersByDateRangeAndDealerId(year,month, dealerId, DBConnection);

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

        public List<CustomerOrderSalesCount> GetSalesCountByDealerId(int year, int month, string date, int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetSalesCountByDealerId(year, month, date, dealerId, DBConnection);

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

        public CustomerOrder getCustomerOrderById(int id)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.getCustomerOrderById(id, DBConnection);

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

        public List<CustomerOrderSalesCountToday> GetTodaySalesCountByDealerId(string date, int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetTodaySalesCountByDealerId( date, dealerId, DBConnection);

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

        public List<CustomerOrderSalesCount> GetThisMonthSalesCountByDealerId(int year, int month, int dealerId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerOrderDAO.GetThisMonthSalesCountByDealerId(year, month, dealerId, DBConnection);

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
