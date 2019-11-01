using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ContactsList.Infrasctructure.Model;
using ContactsList.Infrasctructure.Repositories.Abstract;

namespace ContactsList.Infrasctructure.Repositories
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
    }
}