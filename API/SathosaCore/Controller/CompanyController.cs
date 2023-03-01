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
    public interface CompanyController
    {
        int companyCreate(Company company);
        int updateCompany(Company company);
        int deleteCompany(int companyId);
        List<Company> GetAllCompanies();
    }

    public class CompanyControllerImpl : CompanyController
    {
        DBConnection DBConnection;
        CompanyDAO companyDAO = DAOFactory.CreateCompanyDAO();

        public int companyCreate(Company company)
        {
            try
            {
                DBConnection = new DBConnection();

                return companyDAO.companyCreate(company, DBConnection);

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
        public int updateCompany(Company company)
        {
            try
            {
                DBConnection = new DBConnection();

                return companyDAO.updateCompany(company, DBConnection);

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

        public int deleteCompany(int companyId)
        {
            try
            {
                DBConnection = new DBConnection();
                return companyDAO.deleteCompany(companyId, DBConnection);

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

        public List<Company> GetAllCompanies()
        {
            try
            {
                DBConnection = new DBConnection();
                return companyDAO.GetAllCompanies(DBConnection);

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
