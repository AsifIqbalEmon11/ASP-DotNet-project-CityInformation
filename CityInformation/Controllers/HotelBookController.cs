using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CityInformation.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelBookController : ApiController
    {
        [Route("api/HotelBook")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = HotelBookService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/HotelBook/add")]
        [HttpPost]
        public HttpResponseMessage Add(HotelBookDTO HotelBook)
        {
            try
            {
                var data = HotelBookService.Add(HotelBook);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/HotelBook/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelBookService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/HotelBook/update")]
        [HttpPost]
        public HttpResponseMessage Update(HotelBookDTO HotelBook)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelBookService.Update(HotelBook));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/HotelBook/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelBookService.Delete(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
