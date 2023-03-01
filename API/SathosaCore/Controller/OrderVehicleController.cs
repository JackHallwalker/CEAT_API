using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using SupremeCourtCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Controller
{
    public interface OrderVehicleController
    {
        int Save(OrderVehicle orderVehicle);
        List<OrderVehicle> GetOrderVehiclesByVehicleId(int vehicleId);
        int Update(OrderVehicle orderVehicle);
        OrderVehicle GetOrderVehicleByOrderId(int orderId);
    }

    public class OrderVehicleControllerImpl : OrderVehicleController
    {
        DBConnection dBConnection;
        OrderVehicleDAO orderVehicleDAO = DAOFactory.CreateOrderVehicleDAO();

        public int Save(OrderVehicle orderVehicle)
        {
            try
            {
                dBConnection = new DBConnection();

                return orderVehicleDAO.Save(orderVehicle, dBConnection);

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

        public int Update(OrderVehicle orderVehicle)
        {
            try
            {
                dBConnection = new DBConnection();

                return orderVehicleDAO.Update(orderVehicle, dBConnection);

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

        public List<OrderVehicle> GetOrderVehiclesByVehicleId(int vehicleId)
        {
            try
            {
                dBConnection = new DBConnection();

                return orderVehicleDAO.GetOrderVehiclesByVehicleId(vehicleId, dBConnection);

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

        //public int deleteCustomer(int customerId)
        //{
        //    try
        //    {
        //        dBConnection = new DBConnection();
        //        return customerDAO.deleteCustomer(customerId, dBConnection);

        //    }
        //    catch (Exception)
        //    {
        //        dBConnection.RollBack();

        //        throw;
        //    }
        //    finally
        //    {
        //        if (dBConnection.con.State == System.Data.ConnectionState.Open)
        //            dBConnection.Commit();
        //    }
        //}



        public OrderVehicle GetOrderVehicleByOrderId(int orderId)
        {
            try
            {
                dBConnection = new DBConnection();
                return orderVehicleDAO.GetOrderVehicleByOrderId(orderId, dBConnection);
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
