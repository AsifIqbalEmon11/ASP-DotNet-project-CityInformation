using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityInformation.Controllers
{
    public class ManagerController : ApiController
    {
        [Route("api/manager")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ManagerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
