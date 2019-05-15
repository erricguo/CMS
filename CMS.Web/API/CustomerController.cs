using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS.BLL.Services;

namespace CMS.Web.API
{
    public class CustomerController : ApiController
    {
        private CustomerService service;

        public CustomerController()
        {
            service = new CustomerService();
        }

        [HttpGet]
        public HttpResponseMessage Customer()
        {
            try
            {
                var datas = service.Get();
                var Rvl = new { Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}
