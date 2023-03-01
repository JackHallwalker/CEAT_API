using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ComplaintCategoryDAO
    {
        List<ComplaintCategory> GetAllComplaintCategories(DBConnection dbConnection);
        List<ComplaintCategory> GetAllComplaintCategoriesByComTypeId(int comTypeId,DBConnection dbConnection);
        ComplaintCategory GetComplaintCategoriesByComCatId(int comCatId, DBConnection dbConnection);
        int AddComplaintCategory(ComplaintCategory complaintcategory, DBConnection dbConnection);
    }

    public class ComplaintCategoryDAOImpl : ComplaintCategoryDAO
    {
        public List<ComplaintCategory> GetAllComplaintCategories(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_CATEGORY ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ComplaintCategory>(dbConnection.dr);
        }

        public int AddComplaintCategory(ComplaintCategory complaintcategory, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO COMPLAINT_CATEGORY(NAME, COMPLAINT_TYPE_ID) VALUES('" + complaintcategory.name + "',"+ complaintcategory.complaintTypeID+") SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<ComplaintCategory> GetAllComplaintCategoriesByComTypeId(int comTypeId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_CATEGORY WHERE COMPLAINT_TYPE_ID = " +comTypeId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ComplaintCategory>(dbConnection.dr);
        }

        public ComplaintCategory GetComplaintCategoriesByComCatId(int comCatId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPLAINT_CATEGORY WHERE ID = " + comCatId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ComplaintCategory>(dbConnection.dr);
        }
    }
}
