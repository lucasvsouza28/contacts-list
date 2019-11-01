using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsList.Infrasctructure.Model {

    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}