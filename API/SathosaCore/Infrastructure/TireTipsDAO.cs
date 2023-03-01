using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface TireTipsDAO
    {
        int createTireTips(TireTips tireTips, DBConnection dbConnection);
        int updateTireTips(TireTips tireTips, DBConnection dbConnection);
        int deleteTireTips(int tireTipId, DBConnection dbConnection);
        List<TireTips> GetAllTireTips(DBConnection dbConnection);
    }

    public class TireTipsDAOImpl : TireTipsDAO
    {
        public int createTireTips(TireTips tireTips, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO TIRE_TIPS (TITLE, BODY, URL) values('" + tireTips.title + "','" + tireTips.body + "','" + tireTips.url + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int deleteTireTips(int tireTipId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "DELETE FROM TIRE_TIPS WHERE ID =" + tireTipId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<TireTips> GetAllTireTips(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM TIRE_TIPS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TireTips>(dbConnection.dr);
        }

        public int updateTireTips(TireTips tireTips, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update TIRE_TIPS set TITLE = '" + tireTips.title + "', BODY = '" + tireTips.body + "', URL = '" + tireTips.url + "'  where ID = " + tireTips.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }
    }
}
