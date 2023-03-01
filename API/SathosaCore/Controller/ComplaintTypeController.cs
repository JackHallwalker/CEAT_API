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
    public interface ComplaintTypeController
    {
        List<ComplaintType> GetAllComplaintTypes();
        int AddComplaintType(ComplaintType complaintType);
    }

    public class ComplaintTypeControllerImpl : ComplaintTypeController
    {
        DBConnection DBConnection;
        ComplaintTypeDAO complaintTypeDAO = DAOFactory.CreateComplaintTypeDAO();

        public List<ComplaintType> GetAllComplaintTypes()
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintTypeDAO.GetAllComplaintTypes(DBConnection);

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

        public int AddComplaintType(ComplaintType complaintType)
        {
            try
            {
                DBConnection = new DBConnection();

                return complaintTypeDAO.AddComplaintType(complaintType, DBConnection);

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
