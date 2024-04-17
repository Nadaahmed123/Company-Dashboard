using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Entities;
namespace Company.BLL.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        int Add(Employee employee);
        int Update(Employee employee);
        int Delete(Employee employee);
    }
}
