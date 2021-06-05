using eSpazaShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSpazaShop.Repositories.Implementations
{

   //Repository will conduct all CRUD operations .Uses the Set Method for all kinds of tables and classe unNammed
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        //passs the DbContext here
        protected DbContext _dbContext;

        //Inject the context object into the contructor
        public Repository(DbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        public void Delete(object Id)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(Id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
         
        }
        public TEntity Find(object Id)
        {
            //finds primary key of any table
            return _dbContext.Set<TEntity>().Find(Id);
        }
       public  IEnumerable<TEntity>GetAll()
        {
            //returns a list of all kinds of entity
            return _dbContext.Set<TEntity>().ToList();
        }
       public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
       //method returns rows affected if none changes then it returns zero
       public int SaveChanges()
        {
           return _dbContext.SaveChanges();
        }
       public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
