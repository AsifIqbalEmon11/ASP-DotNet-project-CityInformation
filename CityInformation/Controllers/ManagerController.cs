using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CityInformation.Controllers
{
   [EnableCors("*", "*", "*")]
    public class ManagerController : ApiController
    {
        [Route("api/manager/login")]
        [HttpPost]
        public HttpResponseMessage Login(ManagerDTO manager)
        {
            try
            {
                var token = ManagerAuthService.Authenticate(manager);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

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
