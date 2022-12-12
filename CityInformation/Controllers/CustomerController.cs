using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    public class CustomerController : ApiController
    {
        [Route("api/Customer")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = CustomerService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Customer/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = CustomerService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Customer/add")]
        [HttpPost]
        public HttpResponseMessage Add(CustomerDTO customer)
        {
            var data = CustomerService.Add(customer);

            return Request.CreateResponse(HttpStatusCode.OK, data);


        }

        [Route("api/Customer/update")]
        [HttpPost]
        public HttpResponseMessage Update(CustomerDTO customer)
        {

            var data = CustomerService.Update(customer);

            return Request.CreateResponse(HttpStatusCode.OK, data);


        }

        [Route("api/Customer/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = CustomerService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
