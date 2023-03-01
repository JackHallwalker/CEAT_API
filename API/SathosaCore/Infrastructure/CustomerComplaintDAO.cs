using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface CustomerComplaintDAO
    {
        int createCustomerComplaint(CustomerComplaint customerComplaint, DBConnection dbConnection);
        int updateCustomerComplaint(CustomerComplaint customerComplaint, DBConnection dbConnection);
        int updateCustomerComplaintAssaignee(int id, int assaigneeId, DBConnection dbConnection);
        int updateCustomerComplaintByAssaignee(CustomerComplaint customerComplaint, DBConnection dbConnection);
        int deleteCustomerComplaint(int customerComplaintID, DBConnection dbConnection);
        List<CustomerComplaintDetails> GetAllCustomerComplaints(DBConnection dbConnection);
        List<CustomerComplaint> GetAllCustomerComplaintsByCustomerId(int cusId, DBConnection dbConnection);
        List<CustomerComplaint> GetAllCustomerComplaintsByAssaignee(int assaigneeId, DBConnection dbConnection);
    }

    public class CustomerComplaintDAOImpl : CustomerComplaintDAO
    {
        public int createCustomerComplaint(CustomerComplaint customerComplaint, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO CUSTOMER_COMPLAINT (DEALER_ID, COMPLAINT_CATEGORY_ID, CUSTOMER_ID, COMPLAINT_TYPE_ID,DESCRIPTION, IS_RESOLVED, COMPLAINT_DATE, RESOLVED_DATE)"+
                "values(" + customerComplaint.dealerId + "," + customerComplaint.complaintCategoryId + "," + customerComplaint.customerId + "," + customerComplaint.complaintTypeId + ",'" + customerComplaint.description + "'," + customerComplaint.isResolved + " ,'"+customerComplaint.complaintDate.ToString("yyyy-MM-dd")+"', '"+ customerComplaint.resolvedDate.ToString("yyyy-MM-dd")+"') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateCustomerComplaint(CustomerComplaint customerComplaint, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update CUSTOMER_COMPLAINT set DESCRIPTION = '" + customerComplaint.description + "', IS_RESOLVED = "+customerComplaint.isResolved+ ",RESOLVED_DATE = '"+customerComplaint.resolvedDate.ToString("yyyy-MM-dd")+"'  where ID = " + customerComplaint.id;

            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int deleteCustomerComplaint(int customerComplaintID, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE CUSTOMER_COMPLAINT SET IS_RESOLVED = 1 WHERE ID =" + customerComplaintID;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<CustomerComplaintDetails> GetAllCustomerComplaints(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_COMPLAINT";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerComplaintDetails>(dbConnection.dr);
        }

        public int updateCustomerComplaintAssaignee(int id, int assaigneeId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update CUSTOMER_COMPLAINT set ASSAIGN_TO = " +assaigneeId+ " where ID = " + id;

            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<CustomerComplaint> GetAllCustomerComplaintsByAssaignee(int assaigneeId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_COMPLAINT WHERE ASSAIGN_TO = " +assaigneeId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerComplaint>(dbConnection.dr);
        }

        public int updateCustomerComplaintByAssaignee(CustomerComplaint customerComplaint, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE CUSTOMER_COMPLAINT SET IS_RESOLVED ="+customerComplaint.isResolved+", REMARK_BY_ASSAIGNEE='"+customerComplaint.remark_by_assaignee+"', RESOLVED_DATE='"+customerComplaint.resolvedDate.ToString("yyyy-MM-dd") + "' WHERE ID =" + customerComplaint.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<CustomerComplaint> GetAllCustomerComplaintsByCustomerId(int cusId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM CUSTOMER_COMPLAINT WHERE CUSTOMER_ID="+cusId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CustomerComplaint>(dbConnection.dr);
        }
    }
}
