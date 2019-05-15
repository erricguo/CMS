using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CMS.Domain;
using CMS.Domain.ViewModel;

namespace CMS.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Customers, CustomerViewModel>());
        }
    }
}