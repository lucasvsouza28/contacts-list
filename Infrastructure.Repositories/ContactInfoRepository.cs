using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ContactsList.Infrasctructure.Model;
using ContactsList.Infrasctructure.Repositories.Abstract;

namespace ContactsList.Infrasctructure.Repositories
{
    public class ContactInfoRepository : BaseRepository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(string connectioString)
            : base(connectioString)
        {
        }
    }
}