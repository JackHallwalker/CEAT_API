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
    public interface DealerController
    {
        int dealerCreate(DealerCreation dealer);
        int updateDealer(Dealer dealer);
        int deleteDealer(int dealerId);
        List<Dealer> GetAllDealers();
        Dealer getDealerById(int id);
        List<Dealer> getAllDealersByDistrictId(int districtId);
    }

    public class DealerControllerImpl : DealerController
    {
        DBConnection dBConnection;
        DealerDAO dealerDAO = DAOFactory.CreateDealerDAO();

        public int dealerCreate(DealerCreation dealer)
        {
            try
            {
                dBConnection = new DBConnection();

                return dealerDAO.dealerCreate(dealer, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public int updateDealer(Dealer dealer)
        {
            try
            {
                dBConnection = new DBConnection();

                return dealerDAO.updateDealer(dealer, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public int deleteDealer(int dealerId)
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerDAO.deleteDealer(dealerId, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<Dealer> GetAllDealers()
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerDAO.GetAllDealers(dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public Dealer getDealerById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerDAO.getDealerById(id, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<Dealer> getAllDealersByDistrictId(int districtId)
        {
            try
            {
                dBConnection = new DBConnection();
                return dealerDAO.getAllDealersByDistrictId(districtId, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

    }
}
