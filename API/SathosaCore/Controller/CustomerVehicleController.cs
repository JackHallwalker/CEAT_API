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
    public interface CustomerVehicleController
    {
        int Save(CustomerVehicle customerVehicle);
        List<CustomerVehicle> GetCustomerVehiclesByVehicleId(int vehicleId, int isActive = 0);
        int Update(CustomerVehicle customerVehicle);
        CustomerVehicle GetCustomerVehicleByVehicleNumber(string vehicleNumber, int isActive = 1);

        int Delete(CustomerVehicle customerVehicle);
    }

    public class CustomerVehicleControllerImpl : CustomerVehicleController
    {
        DBConnection dBConnection;
        CustomerVehicleDAO customerVehicleDAO = DAOFactory.CreateCustomerVehicleDAO();

        public int Save(CustomerVehicle customerVehicle)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerVehicleDAO.Save(customerVehicle, dBConnection);

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

        public int Update(CustomerVehicle customerVehicle)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerVehicleDAO.Update(customerVehicle, dBConnection);

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

        public int Delete(CustomerVehicle customerVehicle)
        {
            try
            {
                dBConnection = new DBConnection();

                return customerVehicleDAO.Delete(customerVehicle, dBConnection);

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

        public List<CustomerVehicle> GetCustomerVehiclesByVehicleId(int vehicleId, int isActive = 1)
        {
            try
            {
                dBConnection = new DBConnection();
                return customerVehicleDAO.GetCustomerVehiclesByCustomerId(vehicleId, dBConnection, isActive);



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

            throw new NotImplementedException();
        }



        public CustomerVehicle GetCustomerVehicleByVehicleNumber(string vehicleNumber, int isActive = 1)
        {
            try
            {
                dBConnection = new DBConnection();
                return customerVehicleDAO.GetCustomerVehicleByVehicleNumber(vehicleNumber, dBConnection, isActive);
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