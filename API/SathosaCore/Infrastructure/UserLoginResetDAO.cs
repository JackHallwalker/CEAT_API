using CeatCore.Common;
using CeatCore.Domain;
using SupremeCourtCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeCourtCore.Infrastructure
{
    public interface UserLoginResetDAO
    {
        int Save(UserLoginReset userLoginReset, DBConnection dbConnection);

        UserLoginReset GetUserLoginResetByEmailCheck(int id, DBConnection dbConnection);

        UserLoginReset GetUserLoginResetByEmail(UserLoginReset userLoginReset, DBConnection dbConnection);

    }
    public partial class UserLoginResetDAOimpl : UserLoginResetDAO
    {
        public int Save(UserLoginReset userLoginReset, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO user_login_reset (id, email, verification_code, date_time) values(" + userLoginReset.id + ",'" + userLoginReset.email + "','"
                + userLoginReset.verificationCode + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "');";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteNonQuery());
        }

        public UserLoginReset GetUserLoginResetByEmailCheck(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT TOP 1  * FROM user_login_reset WHERE id = " + id + " AND date_time >= DATEADD(minute, -2, GETDATE()) ORDER BY date_time DESC;";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserLoginReset>(dbConnection.dr);
        }


        public UserLoginReset GetUserLoginResetByEmail(UserLoginReset userLoginReset, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT TOP 1 * FROM user_login_reset WHERE  email = '" + userLoginReset.email + "' AND date_time >= DATEADD(minute, -10, GETDATE()) ORDER BY date_time DESC;";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserLoginReset>(dbConnection.dr);
        }
    }
}
