using System;
using System.Collections;
using System.Collections.Generic;
using contacts_list.Infrasctructure.Model;

namespace contacts_list.Infrasctructure.Repositories.Abstract {

    public interface IBaseRepository<T> where T : BaseEntity
    {        
        List<T> GetAll();

        T GetById(int id, params string[] includes);

        int Insert(T entity);

        void Update(T entity);

        void DeleteById(int id);
    }

}