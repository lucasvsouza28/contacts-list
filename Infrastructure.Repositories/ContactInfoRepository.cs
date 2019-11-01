using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using contacts_list.Infrasctructure.Model;
using contacts_list.Infrasctructure.Repositories.Abstract;

namespace contacts_list.Infrasctructure.Repositories
{
    public class ContactInfoRepository : BaseRepository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(string connectioString)
            : base(connectioString)
        {
        }
    }
}