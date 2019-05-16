using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS.BLL.Services;
using CMS.Domain.ViewModel;

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
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Customer(string CustomerID)
        {
            try
            {
                var datas = service.Get(CustomerID);
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Customer(int CurrPage, int PageSize)
        {
            try
            {
                int TotalRow = 0;
                var datas = service.Get(CurrPage, PageSize,out TotalRow);
                var Result = new { Total = TotalRow, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Result);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /*
        [HttpGet]
        [Route("Customer/{CustomerID}")]
        public HttpResponseMessage Customer(string CustomerID)
        {
            try
            {
                var datas = service.Get(CustomerID);
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }*/

        public HttpResponseMessage Post(CustomerViewModel models)
        {
            try
            {
                service.AddCustomer(models);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Put(CustomerViewModel models)
        {
            try
            {
                service.UpdateCustomer(models);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public HttpResponseMessage Delete(string CustomerID)
        {
            try
            {

                service.DeleteCustomer(CustomerID);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
