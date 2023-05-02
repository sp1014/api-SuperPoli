using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_SuperPoli.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Archivo { get; set; }
        public ICollection<ProductFile> ProductFiles { get; set; }
    }
}

