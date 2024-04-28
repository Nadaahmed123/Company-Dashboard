using Company.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Context;
using Company.DAL.Entities;

namespace Company.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        =>_context.Set<T>().Add(entity);
         

        public void Delete(T entity)
       =>_context.Set<T>().Remove(entity);
        
        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();


        public T GetById(int? id)
        => _context.Set<T>().Find(id);
     
       

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
        
    }
}
