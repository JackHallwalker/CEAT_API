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
    public interface TireTipsController
    {
        int createTireTips(TireTips tireTips);
        int updateTireTips(TireTips tireTips);
        int deleteTireTips(int tireTipId);
        List<TireTips> GetAllTireTips();
    }

    public class TireTipsControllerImpl : TireTipsController
    {
        DBConnection DBConnection;
        TireTipsDAO tireTipsDAO = DAOFactory.CreateTireTipsDAO();

        public int createTireTips(TireTips tireTips)
        {
            try
            {
                DBConnection = new DBConnection();

                return tireTipsDAO.createTireTips(tireTips, DBConnection);

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

        public int deleteTireTips(int tireTipId)
        {
            try
            {
                DBConnection = new DBConnection();

                return tireTipsDAO.deleteTireTips(tireTipId, DBConnection);

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

        public List<TireTips> GetAllTireTips()
        {
            try
            {
                DBConnection = new DBConnection();

                return tireTipsDAO.GetAllTireTips(DBConnection);

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

        public int updateTireTips(TireTips tireTips)
        {
            try
            {
                DBConnection = new DBConnection();

                return tireTipsDAO.updateTireTips(tireTips, DBConnection);

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
