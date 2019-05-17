using CMS.DAL.Interfaces;
using CMS.Domain;
using CMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Repositiry;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class DashBoardServices
    {
        private IRepository<Employees> db;

        public DashBoardServices()
        {
            db = new GenericRepository<Employees>();
        }

        public List<EmpOrdersViewModel> GetEmpOrders()
        {
            List<EmpOrdersViewModel> models = new List<EmpOrdersViewModel>();

            var DbResult = db.Get().ToList();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Employees, EmpOrdersViewModel>()
                                .ForMember(c => c.EmployeeName
                                , x => x.MapFrom(d => $"{d.FirstName} {d.LastName}"))
                                .ForMember(c => c.OrderCount
                                , x => x.MapFrom(d => d.Orders.Count())));
            return Mapper.Map<List<EmpOrdersViewModel>>(DbResult);
        }
    }
}
