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
        public IQueryable<CustomerViewModel> Get()
        {
            try
            {
                var DbResult = db.Get().ToList();
                // Mapping到ViewModel
                return Mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult).AsQueryable();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
    }
}
