using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationApiMVC.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/User/All")]
        public HttpResponseMessage GetAll()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
