﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_SuperPoli.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        public string NameRole { get; set; }
    }
}



