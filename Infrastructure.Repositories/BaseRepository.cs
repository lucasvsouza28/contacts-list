using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ContactsList.Infrasctructure.Model;
using ContactsList.Infrasctructure.Repositories.Abstract;

namespace ContactsList.Infrasctructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected ContactsContext Context { get;set;}
        
        public BaseRepository(string connectionString)
        {
            this.Context = new ContactsContext(connectionString);
        }

        public virtual List<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public virtual T GetById(int id, params string[] includes)
        {
            var query = this.Context.Set<T>().AsQueryable();

            if (includes != null) {
                foreach (var i in includes) {
                    query = query.Include(i);
                }
            }

            return query.AsNoTracking().FirstOrDefault( e => e.Id == id);
        }

        public virtual int Insert(T entity)
        {
            this.Context.Set<T>().Add(entity);
            return this.Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            DbSet<T> dbSet = this.Context.Set<T>();
            var exists = dbSet.AsNoTracking().Any(e => e.Id == entity.Id);
            if (exists)
                dbSet.Update(entity);
            else 
                dbSet.Add(entity);

            this.Context.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            this.Context.Set<T>().Remove(this.GetById(id));
            this.Context.SaveChanges();
        }
        
    }
}