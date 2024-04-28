using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { set; get; }
        public IEmployeeRepository EmployeeRepository { set; get; }
        public int Complete();
    }
}
