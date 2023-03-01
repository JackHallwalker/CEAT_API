using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface UserTypeDAO
    {
        List<UserType> GetAllUserTypes(DBConnection dbConnection);
        UserType getUserTypeById(int id, DBConnection dbConnection);
    }

    public class UserTypeDAOImpl : UserTypeDAO
    {
        public List<UserType> GetAllUserTypes(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM USER_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<UserType>(dbConnection.dr);
        }

        public UserType getUserTypeById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM USER_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserType>(dbConnection.dr);
        }
    }
}
