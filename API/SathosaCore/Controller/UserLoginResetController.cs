using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using SupremeCourtCore.Domain;
using SupremeCourtCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeCourtCore.Controller
{
    public interface UserLoginResetController
    {
        int Save(UserLoginReset userLoginReset);

        UserLoginReset GetUserLoginResetCheck(int id);
        UserLoginReset GetUserLoginReset(UserLoginReset userLoginReset);

    }
    public partial class UserLoginResetControllerimpl : UserLoginResetController
    {
        DBConnection dBConnection;
        UserLoginResetDAO userLoginResetDAO = DAOFactory.CreateUserLoginResetDAO();
        public int Save(UserLoginReset userLoginReset)
        {
            try
            {
                dBConnection = new DBConnection();

                return userLoginResetDAO.Save(userLoginReset, dBConnection);

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
        public UserLoginReset GetUserLoginReset(UserLoginReset userLoginReset)
        {
            try
            {
                dBConnection = new DBConnection();

                return userLoginResetDAO.GetUserLoginResetByEmail(userLoginReset, dBConnection);

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

        public UserLoginReset GetUserLoginResetCheck(int id)
        {
            try
            {
                dBConnection = new DBConnection();

                return userLoginResetDAO.GetUserLoginResetByEmailCheck(id, dBConnection);

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
