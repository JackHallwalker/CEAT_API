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
    public interface AdminController
    {
        int adminCreate(AdminCreate admin);
        List<Admin> GetAllAdmins();
        int updateAdmin(Admin admin);
        //int deleteCustomer(int customerId);

        Admin getAdminById(int id);
    }

    public class AdminControllerImpl : AdminController
    {
        DBConnection dBConnection;
        AdminDAO adminDAO = DAOFactory.CreateAdminDAO();

        public int adminCreate(AdminCreate admin)
        {
            try
            {
                dBConnection = new DBConnection();

                return adminDAO.adminCreate(admin, dBConnection);

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

        public int updateAdmin(Admin admin)
        {
            try
            {
                dBConnection = new DBConnection();

                return adminDAO.updateAdmin(admin, dBConnection);

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

        public List<Admin> GetAllAdmins()
        {
            try
            {
                dBConnection = new DBConnection();
                return adminDAO.GetAllAdmins(dBConnection);

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

        public Admin getAdminById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return adminDAO.getAdminById(id, dBConnection);
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