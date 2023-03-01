using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using CeatAPI;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CeatAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
         
                GlobalConfiguration.Configuration                
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "CeatAPI");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\CeatAPI.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                   
                })                
                .EnableSwaggerUi(c => { });
        }
    }

}