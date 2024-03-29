﻿using BLL.DTO;
using BLL.Service;
using CityInformation.Auth;
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
    public class HotelController : ApiController
    {

        [ManagerLogged]
        [Route("api/hotel")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = HotelService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [ManagerLogged]
        [Route("api/hotel/add")]
        [HttpPost]
        public HttpResponseMessage Add(HotelDTO hotel)
        {
            try
            {
                var data = HotelService.Add(hotel);
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
        [ManagerLogged]
        [Route("api/hotels/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelService.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/hotels/update")]
        [HttpPost]
        public HttpResponseMessage Update(HotelDTO hotel)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelService.Update(hotel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/hotels/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, HotelService.Delete(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
