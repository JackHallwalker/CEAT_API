using CeatCore.Common;
using CeatCore.Controller;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CeatAPI.Controllers
{
    public class UserTypeApiController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/v1/GetAllUserTypes/")]
        public IEnumerable<UserType> GetAllUserTypes()
        {
            UserTypeController userTypeController = ControllerFactory.CreateUserTypeController();

            return userTypeController.GetAllUserTypes();
        }

        [HttpGet]
        [Route("api/v1/getUserTypeById/{id?}")]
        public UserType getUserTypeById(int id)
        {
            UserTypeController userTypeController = ControllerFactory.CreateUserTypeController();

            return userTypeController.getUserTypeById(id);
        }
    }
}
