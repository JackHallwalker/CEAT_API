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
    public interface CustomerController
    {
        int customerCreate(CustomerCreation customer);
        int updateCustomer(Customer customer);
        int deleteCustomer(int customerId);
        List<Customer> GetAllCustomers();
        int updateAveRuningRateById(int id, double aveRuningRate);
        List<Customer> GetAllCustomersByDealerId(int dealerId);
        Customer getCustomerById(int id);
    }

    public class CustomerControllerImpl : CustomerController
    {
        DBConnection dBConnection;
        CustomerDAO customerDAO = DAOFactory.CreateCustomerDAO();

        public int customerCreate(CustomerCreation customer)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerDAO.customerCreate(customer, dBConnection);

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

        public int updateCustomer(Customer customer)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerDAO.updateCustomer(customer, dBConnection);

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

        public int deleteCustomer(int customerId)
        {
            try
            {
                dBConnection = new DBConnection();
                return customerDAO.deleteCustomer(customerId, dBConnection);

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

        public List<Customer> GetAllCustomers()
        {
            try
            {
                dBConnection = new DBConnection();
                return customerDAO.GetAllCustomers(dBConnection);

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

        public int updateAveRuningRateById(int id, double aveRuningRate)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerDAO.updateAveRuningRateById(id,aveRuningRate, dBConnection);

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

        public List<Customer> GetAllCustomersByDealerId(int dealerId)
        {
            try
            {
                dBConnection = new DBConnection();
                return customerDAO.GetAllCustomersByDealerId(dealerId, dBConnection);

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

        public Customer getCustomerById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return customerDAO.getCustomerById(id, dBConnection);
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