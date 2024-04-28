using Company.BLL.Interfaces;
using Company.DAL.Context;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DAL; 

namespace Company.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
          _context = context;
        }
          public Employee GetById(int id)
         => _context.Employees.FirstOrDefault(x => x.Id == id);
         public IEnumerable<Employee> GetEmployeeByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(string name)
        {
            var result = _context.Employees.Where(employee =>
            employee.Name.Trim().ToLower().Contains(name.Trim().ToLower())
            ||  employee.Email.Trim().ToLower().Contains(name.Trim().ToLower()));
            return result;
        }
     
    }
}