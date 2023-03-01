using CeatCore.Common;
using CeatCore.Domain;
using SupremeCourtCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface OrderVehicleDAO
    {
        int Save(OrderVehicle orderVehicle, DBConnection dbConnection);
        int Update(OrderVehicle orderVehicle, DBConnection dbConnection);
        List<OrderVehicle> GetOrderVehiclesByVehicleId(int vehicleId, DBConnection dbConnection);
        OrderVehicle GetOrderVehicleByOrderId(int orderId, DBConnection dbConnection);

    }

    public class OrderVehicleDAOImpl : OrderVehicleDAO
    {
        public int Save(OrderVehicle orderVehicle, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO order_vehicle ( order_id , vehicle_id) values(" + orderVehicle.orderId + "," + orderVehicle.vehicleId + ") SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int Update(OrderVehicle orderVehicle, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE order_vehicle SET  order_id = " + orderVehicle.orderId + ", vehicle_id = " + orderVehicle.vehicleId + " WHERE id = " + orderVehicle.id;
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<OrderVehicle> GetOrderVehiclesByVehicleId(int vehicleId, DBConnection dbConnection)
        {

            dbConnection.cmd.CommandText = "select * from order_vehicle where vehicle_id = " + vehicleId;


            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderVehicle>(dbConnection.dr);
        }



        public OrderVehicle GetOrderVehicleByOrderId(int orderId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select * from order_vehicle where order_id = " + orderId;
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<OrderVehicle>(dbConnection.dr);
        }
    }
}
