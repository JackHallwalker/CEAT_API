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
    public interface OrderDetailsController
    {
        int createOrderDetails(OrderDetails OrderDetail);
        int updateOrderDetails(OrderDetails OrderDetail);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<OrderDetails> GetAllOrderDetails(int customerOrderId);
        List<OrderDetails> GetAllOrderDetailsByCustomerId(int cusId);
        int UpdateOrderDetailStatusByorDeId(int orDeId, int isReplaced);
        List<OrderDetails> GetAllOrderDetailsByCustomerOrderId(int cusOrderId);
        List<OrderDetailsWithCount> getPreviousBuyingDealersByCustomerid(int cusId);
        OrderDetails getOrderDetailById(int id);
    }

    public class OrderDetailsControllerImpl : OrderDetailsController
    {
        DBConnection DBConnection;
        OrderDetailsDAO orderDetailsDAO = DAOFactory.CreateOrderDetailsDAO();

        public int createOrderDetails(OrderDetails OrderDetail)
        {
            try
            {
                DBConnection = new DBConnection();

                return orderDetailsDAO.createOrderDetails(OrderDetail, DBConnection);

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

        public int updateOrderDetails(OrderDetails OrderDetail)
        {
            try
            {
                DBConnection = new DBConnection();

                return orderDetailsDAO.updateOrderDetails(OrderDetail, DBConnection);

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

        public List<OrderDetails> GetAllOrderDetails(int customerOrderId)
        {
            try
            {
                DBConnection = new DBConnection();
                return orderDetailsDAO.GetAllOrderDetails(DBConnection);

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

        public List<OrderDetails> GetAllOrderDetailsByCustomerId(int cusId)
        {
            try
            {
                DBConnection = new DBConnection();
                return orderDetailsDAO.GetAllOrderDetailsByCustomerId(cusId, DBConnection);

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

        public int UpdateOrderDetailStatusByorDeId(int orDeId, int isReplaced)
        {
            try
            {
                DBConnection = new DBConnection();
                if (orderDetailsDAO.CheckUserOrderDetailExitsById(orDeId, DBConnection))
                {
                    return orderDetailsDAO.UpdateOrderDetailStatusByorDeId(orDeId, isReplaced, DBConnection);
                }
                else
                {
                    return 0;
                }


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


        public List<OrderDetails> GetAllOrderDetailsByCustomerOrderId(int cusOrderId)
        {
            try
            {
                DBConnection = new DBConnection();
                return orderDetailsDAO.GetAllOrderDetailsByCustomerOrderId(cusOrderId, DBConnection);

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

        public List<OrderDetailsWithCount> getPreviousBuyingDealersByCustomerid(int cusId)
        {
            try
            {
                DBConnection = new DBConnection();
                return orderDetailsDAO.getPreviousBuyingDealersByCustomerid(cusId, DBConnection);

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

        public OrderDetails getOrderDetailById(int id)
        {
            try
            {
                DBConnection = new DBConnection();
                return orderDetailsDAO.getOrderDetailById(id, DBConnection);

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
