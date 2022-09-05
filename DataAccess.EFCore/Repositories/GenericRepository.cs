using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EFCore.Repositories
{
    //This class will implement the IGenericRepository Interface.
    //We will also inject the ApplicationContext here.
    //This way we are hiding all the actions related to the dbContext object within Repository Classes.
    //Also note that,
    //for the ADD and Remove Functions,
    //we just do the operation on the dbContext object.
    //But we are not yet commiting/updating/saving the changes to the database whatsover.
    //This is not something to be done in a Repository Class.
    //We would need Unit of Work Pattern for these cases where you commit data to the database. 
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
