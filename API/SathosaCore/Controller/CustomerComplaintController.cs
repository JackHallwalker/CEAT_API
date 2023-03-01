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
    public interface CustomerComplaintController
    {
        int createCustomerComplaint(CustomerComplaint customerComplaint);
        int updateCustomerComplaint(CustomerComplaint customerComplaint);
        int updateCustomerComplaintAssaignee(int id, int assaigneeId);
        int deleteCustomerComplaint(int customerComplaintID);
        List<CustomerComplaintDetails> GetAllCustomerComplaints();
        List<CustomerComplaint> GetAllCustomerComplaintsByAssaignee(int assaigneeId);
        List<CustomerComplaint> GetAllCustomerComplaintsByCustomerId(int cusId);
        int updateCustomerComplaintByAssaignee(CustomerComplaint customerComplaint);
    }

    public class CustomerComplaintControllerImpl : CustomerComplaintController
    {
        DBConnection DBConnection;
        CustomerComplaintDAO customerComplaintDAO = DAOFactory.CreateCustomerComplaintDAO();

        public int createCustomerComplaint(CustomerComplaint customerComplaint)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerComplaintDAO.createCustomerComplaint(customerComplaint, DBConnection);

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

        public int updateCustomerComplaint(CustomerComplaint customerComplaint)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerComplaintDAO.updateCustomerComplaint(customerComplaint, DBConnection);

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

        public int deleteCustomerComplaint(int customerComplaintID)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerComplaintDAO.deleteCustomerComplaint(customerComplaintID, DBConnection);

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

        public List<CustomerComplaintDetails> GetAllCustomerComplaints()
        {
            try
            {
                DBConnection = new DBConnection();
                return customerComplaintDAO.GetAllCustomerComplaints(DBConnection);

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

        public int updateCustomerComplaintAssaignee(int id, int assaigneeId)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerComplaintDAO.updateCustomerComplaintAssaignee(id, assaigneeId, DBConnection);

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

        public List<CustomerComplaint> GetAllCustomerComplaintsByAssaignee(int assaigneeId)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerComplaintDAO.GetAllCustomerComplaintsByAssaignee(assaigneeId, DBConnection);

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

        public int updateCustomerComplaintByAssaignee(CustomerComplaint customerComplaint)
        {
            try
            {
                DBConnection = new DBConnection();

                return customerComplaintDAO.updateCustomerComplaintByAssaignee(customerComplaint, DBConnection);

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

        public List<CustomerComplaint> GetAllCustomerComplaintsByCustomerId(int cusId)
        {
            try
            {
                DBConnection = new DBConnection();
                return customerComplaintDAO.GetAllCustomerComplaintsByCustomerId(cusId, DBConnection);

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
