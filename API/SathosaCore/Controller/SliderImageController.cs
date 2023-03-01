using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Controller
{
    public interface SliderImageController
    {
        int createSliderImage(SliderImage sliderImage);
        int updateSliderImage(SliderImage sliderImage);
        int deleteSliderImage(int sliderImageId);
        List<SliderImage> GetSliderImages();
        SliderImage getSliderImageById(int id);
    }

    public class SliderImageControllerImpl : SliderImageController
    {
        DBConnection DBConnection;
        SliderImageDAO sliderImageDAO = DAOFactory.CreateSliderImageDAO();

        public int createSliderImage(SliderImage sliderImage)
        {
            try
            {
                DBConnection = new DBConnection();

                return sliderImageDAO.createSliderImage(sliderImage, DBConnection);

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

        public int deleteSliderImage(int sliderImageId)
        {
            try
            {
                DBConnection = new DBConnection();

                return sliderImageDAO.deleteSliderImage(sliderImageId, DBConnection);

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

        public SliderImage getSliderImageById(int id)
        {
            try
            {
                DBConnection = new DBConnection();

                return sliderImageDAO.getSliderImageById(id, DBConnection);

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

        public List<SliderImage> GetSliderImages()
        {
            try
            {
                DBConnection = new DBConnection();

                return sliderImageDAO.GetSliderImages(DBConnection);

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

        public int updateSliderImage(SliderImage sliderImage)
        {
            try
            {
                DBConnection = new DBConnection();

                return sliderImageDAO.updateSliderImage(sliderImage, DBConnection);

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
