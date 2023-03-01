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
    public interface ComplaintOrderController
    {
        int createComplaintOrder(ComplaintOrder complaintOrder);
        int updateComplaintOrder(ComplaintOrder complaintOrder);
        int deleteComplaintOrder(int compcomplaintOrderId);
        List<ComplaintOrder> GetAllComplaintOrders();
        List<ComplaintOrder> GetAllComplaintOrdersByCustomerComplaintId(int CusComId);
    }

    public class ComplaintOrderControllerImpl : ComplaintOrderController
    {
        DBConnection DBConnection;
        ComplaintOrderDAO complaintOrderDAO = DAOFactory.CreateComplaintOrderDAO();

        public int createComplaintOrder(ComplaintOrder complaintOrder)
        {
            try
            {
                DBConnection = new DBConnection();

                return complaintOrderDAO.createComplaintOrder(complaintOrder, DBConnection);

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

        public int updateComplaintOrder(ComplaintOrder complaintOrder)
        {
            try
            {
                DBConnection = new DBConnection();

                return complaintOrderDAO.updateComplaintOrder(complaintOrder, DBConnection);

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

        public int deleteComplaintOrder(int complaintOrderId)
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintOrderDAO.deleteComplaintOrder(complaintOrderId, DBConnection);

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

        public List<ComplaintOrder> GetAllComplaintOrders()
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintOrderDAO.GetAllComplaintOrders(DBConnection);

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

        public List<ComplaintOrder> GetAllComplaintOrdersByCustomerComplaintId(int CusComId)
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintOrderDAO.GetAllComplaintOrdersByCustomerComplaintId(CusComId, DBConnection);

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
