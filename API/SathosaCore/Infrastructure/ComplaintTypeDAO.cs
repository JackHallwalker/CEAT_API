using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ComplaintTypeDAO
    {
        List<ComplaintType> GetAllComplaintTypes(DBConnection dbConnection);
        int AddComplaintType(ComplaintType complaintType, DBConnection dbConnection);
    }

    public class ComplaintTypeDAOImpl : ComplaintTypeDAO
    {
        public List<ComplaintType> GetAllComplaintTypes(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ComplaintType>(dbConnection.dr);
        }

        public int AddComplaintType(ComplaintType complaintType, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO COMPLAINT_TYPE(NAME) VALUES('" + complaintType.name + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }
    }
}
