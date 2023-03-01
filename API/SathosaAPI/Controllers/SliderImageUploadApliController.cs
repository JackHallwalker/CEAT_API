using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using Microsoft.AspNetCore.Hosting;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CeatAPI.Controllers
{
    
    public class SliderImageUploadApiController : ApiController
    {
        //correct code for image upload backend
        //[HttpPost]
        //[Route("api/v1/CreateRiderDocument")]
        //public HttpResponseMessage CreateRiderDocument([FromBody] UploadImage value)
        //{
        //    //RiderDocumentController riderDocumentController = ControllerFactory.CreateRiderDocumentController();
        //    //List<RiderDocument> riderDocumentList = new List<RiderDocument>();

        //    //int rowCount = 0;
        //    //foreach (var riderDocument in value.riderDocumentOnlines)
        //    //{
        //    //    riderDocumentList.Add((RiderDocument)Utility.cloneObject(riderDocument, new RiderDocument()));

        //        //string imgbase = riderDocumentList[rowCount].ImageUrl;

        //        string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/wwwroot/SliderImages/");
        //        int fileCount = Directory.GetFiles(folderPath, ".", SearchOption.TopDirectoryOnly).Length + 1;
        //        string fileName = "SliderImage" + fileCount + ".png";
        //        string imagePath = folderPath + fileName;
        //        //string base64StringData = imgbase;
        //        //string cleandata = base64StringData;
        //        byte[] data = System.Convert.FromBase64String(value.image);
        //        MemoryStream ms = new MemoryStream(data);
        //        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        //        img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

        //        //riderDocumentList[rowCount].ImageUrl = imagePath;
        //       // riderDocumentList[rowCount].ImageUrl = "http:/rider-uat.melstasoft.com/Images/" + fileName;
        //    //}


        //    //int result = riderDocumentController.SaveRiderDocuments(riderDocumentList);
        //    if (fileCount > 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, "Documents Saved Successfully");
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong");
        //    }
        //}





        // public static IWebHostEnivironment _webHostEnivironment;

        //[Route("uploadImage")]
        //public async Task<string> UploadImage(UploadImage imageDetail)
        //{

        //byte[] bytes = Convert.FromBase64String(imageDetail.image);

        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //    }
        //    //string name;
        //    image.Save("wwwroot//image." + imageDetail.type, ImageFormat.Png);
        //    return "ok";


        //}

        //[HttpPost]
        //[Route("api/v1/upload/")]
        //public string UploadImage([FromBody] IFormFile file)
        //{
        //    try
        //    {
        //        // getting file original name
        //        string FileName = file.FileName;

        //        // combining GUID to create unique name before saving in wwwroot
        //        string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

        //        // getting full path inside wwwroot/images
        //        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", FileName);

        //        // copying file
        //        file.CopyTo(new FileStream(imagePath, FileMode.Create));

        //        return "File Uploaded Successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //[HttpPost]
        //[Route("api/v1/upload2/")]
        //public string UploadImageFromStream([FromBody] string strm)
        //{
        //    try
        //    {
        //        // getting images folder path
        //        string filepath = "wwwroot/MyImage.png";
        //        // converting base64 stream 
        //        var bytess = Convert.FromBase64String(strm);
        //        // converting to file
        //        using (var imageFile = new FileStream(filepath, FileMode.Create))
        //        {
        //            imageFile.Write(bytess, 0, bytess.Length);
        //            imageFile.Flush();
        //        }
        //        return "File Uploaded Successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }
        //}
    }
}
