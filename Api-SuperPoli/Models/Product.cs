using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_SuperPoli.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public bool Activo { get; set; }
        public string NameProduct { get; set; }
        public float Price { get; set; }
        public string Descriptions { get; set; }
        public int Quantity { get; set; }
        public bool promotion { get; set; }

        [ForeignKey("File")]
        [NotMapped]
        public int[] IdFile { get; set; }
        public virtual File File { get; set; }

        public ICollection<ProductFile> ProductFile { get; set; }

    }
}
