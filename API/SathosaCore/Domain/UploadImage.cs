using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class UploadImage
    {
        public string image { get; set; }
        public string type { get; set; }
        //public IFormFile file {get;set;}
    }
}
