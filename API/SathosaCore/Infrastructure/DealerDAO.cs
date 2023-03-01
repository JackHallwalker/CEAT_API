using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface DealerDAO
    {
        int dealerCreate(DealerCreation dealer, DBConnection dbConnection);
        int updateDealer(Dealer dealer, DBConnection dbConnection);
        int deleteDealer(int dealerId, DBConnection dbConnection);
        List<Dealer> GetAllDealers(DBConnection dbConnection);
        Dealer getDealerById(int id, DBConnection dbConnection);
        List<Dealer> getAllDealersByDistrictId(int districtId, DBConnection dbConnection);
    }

    public class DealerDAOImpl : DealerDAO
    {
        public int dealerCreate(DealerCreation dealer, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO DEALER (DISTRICT_ID, NAME, COMPANY_ID, ADDRESS,CONTACT_NUMBER, LONGITUDE, LANGITUDE, REF_CODE, IS_ACTIVE,CREATED_DATE,CREATED_BY,TOWN,TOTAL_REWARDS,QR_CODE, EMAIL) "+
                "values(" + dealer.districtId + ",'" + dealer.name + "'," + dealer.companyId + ",'" + dealer.address + "','" + dealer.contactNumber + "'," + dealer.longitude + ","+dealer.langitude+ ",'" + dealer.refCode + "'," + dealer.isActive + ",'" + dealer.date.ToString("yyyy-MM-dd") + "','" + dealer.createdBy + "','" + dealer.town + "'," + dealer.totalRewards + ",'" + dealer.qrCode + "','" + dealer.email + "' ) SELECT SCOPE_IDENTITY()";
            //return dbConnection.cmd.ExecuteNonQuery();
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int updateDealer(Dealer dealer, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update DEALER set DISTRICT_ID = " + dealer.districtId + ", NAME = '" + dealer.name + "', COMPANY_ID = " + dealer.companyId + ", ADDRESS = '" + dealer.address + "', CONTACT_NUMBER = '" + dealer.contactNumber + "', LONGITUDE = " + dealer.longitude + ", LANGITUDE="+dealer.langitude+ ",REF_CODE='"+dealer.refCode+ "',IS_ACTIVE= "+dealer.isActive+ ",TOWN = '"+dealer.town+"',TOTAL_REWARDS="+dealer.totalRewards+",QR_CODE='"+dealer.qrCode+"', EMAIL='"+dealer.email+"' where ID = " + dealer.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteDealer(int dealerId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "UPDATE DEALER SET IS_ACTIVE = 0 WHERE ID =" + dealerId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Dealer> GetAllDealers(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "select* from dealer d" +
                                           " inner join dealer_login ul on ul.dealer_id = d.id" +
                                           " where exists" +
                                           " (select 1 from dealer d1 where d1.id = ul.dealer_id and d1.is_active = 1)";
            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Dealer>(dbConnection.dr);
        }

        public Dealer getDealerById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM DEALER WHERE IS_ACTIVE=1 AND ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Dealer>(dbConnection.dr);
        }

        public List<Dealer> getAllDealersByDistrictId(int districtId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM DEALER WHERE IS_ACTIVE = 1 AND DISTRICT_ID = " + districtId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Dealer>(dbConnection.dr);
        }
    }
}
