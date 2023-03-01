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
    public interface FittersController
    {
        int fitterCreate(Fitters fitter);
        int updateFitter(Fitters fitter);
        int deleteFitter(int fitterId);
        List<Fitters> GetAllFitters();
        List<Fitters> getFittersByDealerId(int dealerId);
        Fitters getFitterById(int id);
    }

    public class FittersControllerImpl : FittersController
    {
        DBConnection dBConnection;
        FittersDAO fitterDAO = DAOFactory.CreateFittersDAO();

        public int fitterCreate(Fitters fitter)
        {
            try
            {
                dBConnection = new DBConnection();

                return fitterDAO.fitterCreate(fitter, dBConnection);

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

        public int updateFitter(Fitters fitter)
        {
            try
            {
                dBConnection = new DBConnection();

                return fitterDAO.updateFitter(fitter, dBConnection);

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

        public int deleteFitter(int fitterId)
        {
            try
            {
                dBConnection = new DBConnection();
                return fitterDAO.deleteFitter(fitterId, dBConnection);

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

        public List<Fitters> GetAllFitters()
        {
            try
            {
                dBConnection = new DBConnection();
                return fitterDAO.GetAllFitters(dBConnection);

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

        public List<Fitters> getFittersByDealerId(int dealerId)
        {
            try
            {
                dBConnection = new DBConnection();
                return fitterDAO.getFittersByDealerId(dealerId, dBConnection);

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

        public Fitters getFitterById(int id)
        {
            try
            {
                dBConnection = new DBConnection();
                return fitterDAO.getFitterById(id, dBConnection);
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
