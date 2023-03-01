using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface FittersDAO
    {
        int fitterCreate(Fitters fitter, DBConnection dbConnection);
        int updateFitter(Fitters fitter, DBConnection dbConnection);
        int deleteFitter(int fitterId, DBConnection dbConnection);
        List<Fitters> GetAllFitters(DBConnection dbConnection);
        List<Fitters> getFittersByDealerId(int dealerId, DBConnection dbConnection);
        Fitters getFitterById(int id, DBConnection dbConnection);
    }

    public class FittersDAOImpl : FittersDAO
    {
        public int fitterCreate(Fitters fitter, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO FITTERS (DEALER_ID, NAME, IS_ACTIVE) " +
                "values(" + fitter.dealerId + ",'" + fitter.name + "'," + fitter.isActive + " ) SELECT SCOPE_IDENTITY()";
            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int updateFitter(Fitters fitter, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update FITTERS set DEALER_ID = " + fitter.dealerId + ", NAME = '" + fitter.name + "', IS_ACTIVE = " + fitter.isActive + " where ID = " + fitter.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteFitter(int fitterId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE FITTERS SET IS_ACTIVE = 0 WHERE ID =" + fitterId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Fitters> GetAllFitters(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM FITTERS WHERE IS_ACTIVE = 1 ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Fitters>(dbConnection.dr);
        }

        public List<Fitters> getFittersByDealerId(int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM FITTERS WHERE IS_ACTIVE = 1 AND DEALER_ID =" + dealerId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Fitters>(dbConnection.dr);
        }

        public Fitters getFitterById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM FITTERS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Fitters>(dbConnection.dr);
        }
    }
}
