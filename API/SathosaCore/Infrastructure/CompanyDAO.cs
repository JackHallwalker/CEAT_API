using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CompanyDAO
    {
        int companyCreate(Company company, DBConnection dbConnection);
        int updateCompany(Company company, DBConnection dbConnection);
        int deleteCompany(int companyId, DBConnection dbConnection);
        List<Company> GetAllCompanies(DBConnection dbConnection);
    }

    public class CompanyDAOImpl : CompanyDAO
    {
        public int companyCreate(Company company, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO Company (NAME, ADDRESS, EMAIL, FAX) " +
                "values('" + company.name + "','" + company.address + "','" + company.email + "','" +company.fax +"') SELECT SCOPE_IDENTITY()";
            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int updateCompany(Company company, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE COMPANY SET NAME = '" + company.name + "', ADDRESS = '" + company.address + "', EMAIL = '" + company.email + "', FAX = '" + company.fax + "' where ID = " + company.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteCompany(int companyId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "DELETE FROM COMPANY WHERE ID =" + companyId;
            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Company> GetAllCompanies(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Company>(dbConnection.dr);
        }

    }
}
