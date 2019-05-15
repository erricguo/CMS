using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Interfaces;
using CMS.Domain;
using CMS.DAL.Repositiry;
using CMS.Domain.ViewModel;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class CustomerService
    {
        private IRepository<Customers> db;

        public CustomerService()
        {
            db = new GenericRepository<Customers>();
        }

        // <summary>取得所有客戶資料(分頁)</summary>
        /// <returns></returns>
        public List<CustomerViewModel> Get()
        {
            try
            {
                var DbResult = db.Get().ToList();
                // Mapping到ViewModel
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<Customers, CustomerViewModel>());
                return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult);
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

        public IQueryable<CustomerViewModel> Get(int CurrPage,int PageSize , out int TotalRow)
        {
            TotalRow = -1;
            try
            {
                TotalRow = db.Get().ToList().Count;
                var DbResult = db.Get().ToList().Skip((CurrPage-1)*PageSize).Take(PageSize).ToList();
                // Mapping到ViewModel
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<Customers, CustomerViewModel>());
                return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult).AsQueryable();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        /// <summary>取得客戶資訊</summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public IQueryable<CustomerViewModel> Get(string CustomerID , out int TotalRow)
        {
            var DbResult = db.Get().Where(c => c.CustomerID.Trim() == CustomerID.Trim()).ToList();
            TotalRow = DbResult.Count();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Customers, CustomerViewModel>());
            return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult).AsQueryable();
            //return Mapper.Map<Customers, CustomerViewModel>(DbResult);
        }


        public void AddCustomer(CustomerViewModel models)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerViewModel, Customers>());
            var cust = Mapper.Map<CustomerViewModel, Customers>(models);
            db.Insert(cust);
        }

        public void UpdateCustomer(CustomerViewModel models)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerViewModel, Customers>());
            var cust = Mapper.Map<CustomerViewModel, Customers>(models);
            db.Update(cust);
        }

        public void DeleteCustomer(string CustomerID)
        {
            var cust = db.GetByID(CustomerID);
            db.Delete(cust);            
        }
    }
}
