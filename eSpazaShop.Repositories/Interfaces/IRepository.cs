using System.Collections.Generic;


namespace eSpazaShop.Repositories.Interfaces
{
    //make it a public so its accesss to other classes or projects
    //make a generics interface for all common types 
    public interface IRepository<TEntity> where TEntity :  class
    {
        //add common methods which are used across all entities
        //create a IEnumerable list
        IEnumerable<TEntity> GetAll();
        //this help in finding the primary keys.
        //generic types works better with complex types hence object
        TEntity Find(object Id);
        //Method will pass a class that inherit the interface
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        //deleting the keys  
        void Delete(object Id);
        //to commit the database changes
        int SaveChanges();

    }
}
