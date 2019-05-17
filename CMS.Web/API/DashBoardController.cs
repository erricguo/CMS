using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMS.BLL.Services;

namespace CMS.Web.API
{
    public class DashBoardController : ApiController
    {
        private DashBoardServices service;

        public DashBoardController()
        {
            service = new DashBoardServices();
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var datas = service.GetEmpOrders();
                return Request.CreateResponse(HttpStatusCode.OK, datas);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
