using Company.BLL.Interfaces;
using Company.DAL.Context;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

       

       
        public int Add(Employee employee)
        {
           _context.Employees.Add(employee);
           return _context.SaveChanges();
        }

        public int Delete(Employee employee)
        {
           _context.Employees.Remove(employee);
           return _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        => _context.Employees.ToList();


        public Employee GetById(int id)
        =>_context.Employees.FirstOrDefault(x=>x.Id ==id);

        public int Update(Employee employee)
        {
           _context.Employees.Update(employee);
           return _context.SaveChanges();
        }
    }
}
