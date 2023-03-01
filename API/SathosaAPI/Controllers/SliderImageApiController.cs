using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CeatAPI.Controllers
{
    public class SliderImageApiController : ApiController
    {

        [HttpPost]
        [Route("api/v1/createSliderImage/")]
        public HttpResponseMessage createSliderImage([FromBody] SliderImage value)
        {
            try
            {
                SliderImageController sliderImageController = ControllerFactory.CreateSliderImageController();

                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/wwwroot/SliderImages/");
                int fileCount = Directory.GetFiles(folderPath, ".", SearchOption.TopDirectoryOnly).Length + 1;
                string fileName = "SliderImage" + fileCount + ".png";
                string imagePath = folderPath + fileName;
                //string base64StringData = imgbase;
                //string cleandata = base64StringData;
                byte[] data = System.Convert.FromBase64String(value.image_url);
                MemoryStream ms = new MemoryStream(data);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                value.title = fileName;
                int itemId = sliderImageController.createSliderImage(value);

                return Request.CreateResponse(HttpStatusCode.OK, "Slider image created successfully. Id-" + itemId);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/GetSliderImages/")]
        public IEnumerable<SliderImage> GetSliderImages()
        {
            SliderImageController sliderImageController = ControllerFactory.CreateSliderImageController();

            
            var sliderImages = sliderImageController.GetSliderImages();
            
            bool userType = true;
            foreach (var sliderImage in sliderImages)
            {
                if (userType)
                {
                    var aa = ControllerFactory.CreateUserTypeController();
                    sliderImage.userType = aa.getUserTypeById(sliderImage.user_type_id);
                   // sliderImage.image_url = "http://ceat-uat-api.melstasoft.com/SliderImages/" + sliderImage.title;
                   sliderImage.image_url=System.Web.HttpContext.Current.Server.MapPath("~/wwwroot/SliderImages/"+sliderImage.title);
                }
            }

            return sliderImages;
        }



        //[HttpPut]
        //[Route("api/v1/updateSliderImage/")]
        //public HttpResponseMessage updateSliderImage([FromBody] SliderImage value)
        //{
        //    try
        //    {
        //        SliderImageController sliderImageController = ControllerFactory.CreateSliderImageController();
        //        int itemId = sliderImageController.updateSliderImage(value);

        //        return Request.CreateResponse(HttpStatusCode.OK, "Slider image updated successfully.");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
        //    }
        //}

        [HttpDelete]
        [Route("api/v1/deleteSliderImage/{id}")]
        public HttpResponseMessage deleteSliderImage(int id)
        {
            try
            {
                SliderImageController sliderImageController = ControllerFactory.CreateSliderImageController();
                var image = sliderImageController.getSliderImageById(id);
                string path = System.Web.HttpContext.Current.Server.MapPath("~/wwwroot/SliderImages/" + image.title);
                FileInfo file = new FileInfo(path);                

                if (file.Exists)
                {
                    file.Delete();
                }
                int itemId = sliderImageController.deleteSliderImage(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Slider image deleted successfully.");

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong" + ex.Message);
            }
        }

    }
}
