using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModel
{
    public class EmpOrdersViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public int OrderCount { get; set; }

    }
}
