using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoApp.Models;

namespace ToDoApp.DataAccess
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        private DbContext db;
        private DbSet<T> dbSet;

        public BaseRepository()
        {
            db = new ToDoAppContext();
            dbSet = db.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            db.SaveChanges();
        }
    }
}