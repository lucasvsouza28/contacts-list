using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using contacts_list.Infrasctructure.Model;
//using System.Data.Entity;

namespace contacts_list.Infrasctructure.Repositories {

    public class ContactsContext : DbContext {

        private string connectionString;

        public ContactsContext(string _connectionString)
        {
            this.connectionString = _connectionString;
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactInfo> Infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}