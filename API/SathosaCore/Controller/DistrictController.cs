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
    public interface DistrictController
    {
        List<District> GetAllDistrict();
    }

    public class DistrictControllerImpl : DistrictController
    {
        DBConnection DBConnection;
        DistrictDAO districtDAO = DAOFactory.CreateDistrictDAO();

        public List<District> GetAllDistrict()
        {
            try
            {
                DBConnection = new DBConnection();
                return districtDAO.GetAllDistrict(DBConnection);

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
