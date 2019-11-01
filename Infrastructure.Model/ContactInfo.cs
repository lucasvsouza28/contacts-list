using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace contacts_list.Infrasctructure.Model {

    [Table("ContactInfo")]
    public class ContactInfo : BaseEntity
    {
        public ContactInfo(int contactId, eContactType type, string value)
        {
            this.ContactId = contactId;            
            this.Type = type;
            this.Value = value;
        }

        public eContactType Type { get; set; }

        public string Value { get; set; }
        
        public int ContactId { get; set; }
    }
}