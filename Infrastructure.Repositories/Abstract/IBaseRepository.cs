using System;
using System.Collections;
using System.Collections.Generic;
using ContactsList.Infrasctructure.Model;

namespace ContactsList.Infrasctructure.Repositories.Abstract {

    public interface IBaseRepository<T> where T : BaseEntity
    {        
        List<T> GetAll();

        T GetById(int id, params string[] includes);

        int Insert(T entity);

        void Update(T entity);

        void DeleteById(int id);
    }

}