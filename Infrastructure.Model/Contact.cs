using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsList.Infrasctructure.Model {

    [Table("Contact")]
    public class Contact : BaseEntity
    {

        public Contact(string name)
        {
            this.Name = name;
            this.Infos = new List<ContactInfo>();
        }

        public string Name { get; set; }

        public virtual ICollection<ContactInfo> Infos { get;set; }
    }
}