using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface SliderImageDAO
    {
        int createSliderImage(SliderImage sliderImage, DBConnection dbConnection);
        int updateSliderImage(SliderImage sliderImage, DBConnection dbConnection);
        int deleteSliderImage(int sliderImageId, DBConnection dbConnection);
        List<SliderImage> GetSliderImages(DBConnection dbConnection);
        SliderImage getSliderImageById(int id, DBConnection dbConnection);
    }

    public class SliderImageDAOImpl : SliderImageDAO
    {
        public int createSliderImage(SliderImage sliderImage, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO SLIDER_IMAGE (USER_TYPE_ID, DESCRIPTION, TITLE, EFFECTIVE_DATE) values(" + sliderImage.user_type_id + ",'" + sliderImage.description + "','"+sliderImage.title+ "', '" + sliderImage.effective_date.ToString("yyyy-MM-dd") + "') SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }


        public int updateSliderImage(SliderImage sliderImage, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update SLIDER_IMAGE set USER_TYPE_ID = " + sliderImage.user_type_id + ", IMAGE_URL = '" + sliderImage.image_url + "', DESCRIPTION = '" + sliderImage.description + "', TITLE = '"+sliderImage.title+ "', EFFECTIVE_DATE = '"+sliderImage.effective_date.ToString("yyyy-MM-dd")+"' where ID = " + sliderImage.id;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int deleteSliderImage(int sliderImageId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "DELETE FROM SLIDER_IMAGE WHERE ID =" + sliderImageId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<SliderImage> GetSliderImages(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM SLIDER_IMAGE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SliderImage>(dbConnection.dr);
        }

        public SliderImage getSliderImageById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM SLIDER_IMAGE WHERE ID="+id;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<SliderImage>(dbConnection.dr);
        }
    }
}
