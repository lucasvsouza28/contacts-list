using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using contacts_list.Infrasctructure.Model;
using contacts_list.Infrasctructure.Repositories.Abstract;

namespace contacts_list.Infrasctructure.Repositories
{
    public class ContactsRepository : BaseRepository<Contact>, IContactsRepository
    {
        public ContactsRepository(string connectioString)
            : base(connectioString)
        {
        }

        public override void DeleteById(int id)
        {
            var entity = this.GetById(id, "Infos");

            this.Context.Infos.RemoveRange(entity.Infos);
            this.Context.Contacts.Remove(entity);

            this.Context.SaveChanges();
        }

        // public override void Update(Contact entity)
        // {
        //     var entry = this.Context.Entry<Contact>(entity);
        //     entry.State = EntityState.Modified;

        //     foreach (var item in entity.Infos)
        //     {
        //         if (item.Id == 0)
                    
        //     }

        //     this.Context.SaveChanges();
        // }
    }
}