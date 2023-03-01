using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface DistrictDAO
    {
        List<District> GetAllDistrict(DBConnection dbConnection);
    }

    public class DistrictDAOImpl : DistrictDAO
    {
        public List<District> GetAllDistrict(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM DISTRICT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<District>(dbConnection.dr);
        }

    }

}
