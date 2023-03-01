using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface AdminDAO
    {
        int adminCreate(AdminCreate admin, DBConnection dbConnection);
        List<Admin> GetAllAdmins(DBConnection dbConnection);
        int updateAdmin(Admin admin, DBConnection dbConnection);
        //int deleteCustomer(int customerID, DBConnection dbConnection);
        Admin getAdminById(int id, DBConnection dbConnection);

    }

    public class AdminDAOImpl : AdminDAO
    {
        public int adminCreate(AdminCreate admin, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO ADMIN (USER_TYPE_ID, NAME, ADDRESS, IS_ACTIVE) values(" + admin.userTypeId + ",'" + admin.name + "','" + admin.address + "',"+admin.isActive+") SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<Admin> GetAllAdmins(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select * from admin a" +
                                           " inner join admin_login al on al.admin_id = a.id" +
                                           " inner join user_login ul on ul.id = al.user_login_id" +
                                           " where exists (select 1 from admin_login al1 where al1.user_login_id = ul.id) and a.is_Active = 1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Admin>(dbConnection.dr);
        }

        public int updateAdmin(Admin admin, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update ADMIN set USER_TYPE_ID = " + admin.userTypeId + ", NAME = '" + admin.name + "', ADDRESS = '" + admin.address + "' where ID = " + admin.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        //public int deleteCustomer(int customerId, DBConnection dbConnection)
        //{
        //    dbConnection.cmd.CommandText = "UPDATE CUSTOMER SET IS_ACTIVE = 0 WHERE ID =" + customerId;

        //    return dbConnection.cmd.ExecuteNonQuery();
        //}

        public Admin getAdminById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ADMIN WHERE IS_ACTIVE=1 AND ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Admin>(dbConnection.dr);
        }

    }
}
