using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CustomerVehicleDAO
    {
        int Save(CustomerVehicle customerVehicle, DBConnection dbConnection);
        int Update(CustomerVehicle customerVehicle, DBConnection dbConnection);
        List<CustomerVehicle> GetCustomerVehiclesByCustomerId(int customerId, DBConnection dbConnection, int isActive = 1);
        int Delete(CustomerVehicle customerVehicle, DBConnection dbConnection);
        CustomerVehicle GetCustomerVehicleByVehicleNumber(string vehicleNumber, DBConnection dbConnection, int isActive = 1);

    }

    public class CustomerVehicleDAOImpl : CustomerVehicleDAO
    {
        public int Save(CustomerVehicle customerVehicle, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO customer_vehicle ( customer_id, vehicle_number, vehicle_name, is_active) values(" + customerVehicle.customerId + ",'" + customerVehicle.vehicleNumber + "','" + customerVehicle.vehicleName + "'," + customerVehicle.isActive + ") SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int Update(CustomerVehicle customerVehicle, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE customer_vehicle SET  customer_id = " + customerVehicle.customerId + ", vehicle_number = '" + customerVehicle.vehicleNumber + "', vehicle_name = '" + customerVehicle.vehicleNumber + "' WHERE id = " + customerVehicle.id;
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<CustomerVehicle> GetCustomerVehiclesByCustomerId(int customerId, DBConnection dbConnection, int isActive = 1)
        {
            if (isActive != 3)
            {
                dbConnection.cmd.CommandText = "select * from customer_vehicle where customer_id = " + customerId + " AND is_active = " + isActive;
            }
            else
            {
                dbConnection.cmd.CommandText = "select * from customer_vehicle where customer_id = " + customerId;
            }
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerVehicle>(dbConnection.dr);
        }

        public int Delete(CustomerVehicle customerVehicle, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE customer_vehicle SET  is_active = 0 WHERE id = " + customerVehicle.id;
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public CustomerVehicle GetCustomerVehicleByVehicleNumber(string vehicleNumber, DBConnection dbConnection, int isActive = 1)
        {
            if (isActive != 3)
            {
                dbConnection.cmd.CommandText = "SELECT * FROM customer_vehicle WHERE is_active = " + isActive + " AND vehicle_number = '" + vehicleNumber + "' ";
            }
            else
            {
                dbConnection.cmd.CommandText = "SELECT * FROM customer_vehicle WHERE vehicle_number = '" + vehicleNumber + "' ";
            }
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CustomerVehicle>(dbConnection.dr);
        }
    }
}

