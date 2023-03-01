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
    public interface ComplaintCategoryController
    {
        List<ComplaintCategory> GetAllComplaintCategories();
        int AddComplaintCategory(ComplaintCategory complaintType);
        List<ComplaintCategory> GetAllComplaintCategoriesByComTypeId(int comTypeId);
        ComplaintCategory GetComplaintCategoriesByComCatId(int comCatId);
    }

    public class ComplaintCategoryControllerImpl : ComplaintCategoryController
    {
        DBConnection DBConnection;
        ComplaintCategoryDAO complaintCategoryDAO = DAOFactory.CreateComplaintCategoryDAO();

        public List<ComplaintCategory> GetAllComplaintCategories()
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintCategoryDAO.GetAllComplaintCategories(DBConnection);

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

        public int AddComplaintCategory(ComplaintCategory complaintType)
        {
            try
            {
                DBConnection = new DBConnection();

                return complaintCategoryDAO.AddComplaintCategory(complaintType, DBConnection);

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

        public List<ComplaintCategory> GetAllComplaintCategoriesByComTypeId(int comTypeId)
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintCategoryDAO.GetAllComplaintCategoriesByComTypeId(comTypeId, DBConnection);

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

        public ComplaintCategory GetComplaintCategoriesByComCatId(int comCatId)
        {
            try
            {
                DBConnection = new DBConnection();
                return complaintCategoryDAO.GetComplaintCategoriesByComCatId(comCatId, DBConnection);

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
