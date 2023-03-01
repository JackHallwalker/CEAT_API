using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface UserLoginDAO
    {
        UserLoginData GetLoginDetails(string name, string password, DBConnection dbConnection);
        int createUserLogin(UserLogin userLogin, DBConnection dbConnection);
        UserLogin getEmailByUserId(int userId, DBConnection dbConnection);

        UserLogin getUserByEmail(string email, DBConnection dbConnection);
        int updateUserPasswordByUserId(int userId, string password, DBConnection dbConnection);
    }

    public class UserLoginDAOImpl : UserLoginDAO
    {
        public UserLoginData GetLoginDetails(string name, string password, DBConnection dbConnection)
        {

            dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN WHERE NAME = '" + name + "' AND PASSWORD = '" + password + "' ";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserLoginData>(dbConnection.dr);
        }

        public int createUserLogin(UserLogin userLogin, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO USER_LOGIN (USER_TYPE_ID, COMPANY_ID, NAME, PASSWORD, USER_ID) values (" + userLogin.userTypeId + "," + userLogin.companyId + ",'" + userLogin.name + "','" + userLogin.password + "'," + userLogin.userId + ") SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public UserLogin getEmailByUserId(int userId, DBConnection dbConnection)
        {
            //dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN WHERE USER_ID = " + userId + " ";
            //dbConnection.dr = dbConnection.cmd.ExecuteReader();
            //string email = Convert.ToString(dbConnection.cmd.ExecuteScalar());
            //return email

            dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN WHERE ID = " + userId + " ";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserLogin>(dbConnection.dr);
        }

        public UserLogin getUserByEmail(string email, DBConnection dbConnection)
        {
            //dbConnection.cmd.CommandText = "SELECT * FROM USER_LOGIN WHERE USER_ID = " + userId + " ";
            //dbConnection.dr = dbConnection.cmd.ExecuteReader();
            //string email = Convert.ToString(dbConnection.cmd.ExecuteScalar());
            //return email

            dbConnection.cmd.CommandText = "SELECT TOP 1 * FROM USER_LOGIN WHERE NAME = '" + email + "'";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserLogin>(dbConnection.dr);
        }

        public int updateUserPasswordByUserId(int userId, string password, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update USER_LOGIN set PASSWORD = '" + password + "' where ID = " + userId;

            return dbConnection.cmd.ExecuteNonQuery();
        }
    }
}
