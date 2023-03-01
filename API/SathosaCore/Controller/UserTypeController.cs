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
    public interface UserTypeController
    {
        List<UserType> GetAllUserTypes();
        UserType getUserTypeById(int id);
    }


    public class UserTypeControllerImpl : UserTypeController
    {
        DBConnection DBConnection;
        UserTypeDAO userTypeDAO = DAOFactory.CreateUserTypeDAO();

        public List<UserType> GetAllUserTypes()
        {
            try
            {
                DBConnection = new DBConnection();
                return userTypeDAO.GetAllUserTypes(DBConnection);

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

        public UserType getUserTypeById(int id)
        {
            try
            {
                DBConnection = new DBConnection();
                return userTypeDAO.getUserTypeById(id, DBConnection);
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
