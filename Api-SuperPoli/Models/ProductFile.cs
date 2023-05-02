using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SuperPoli.Models
{
    public class ProductFile
    {

        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("File")]     
        public int FileId { get; set; }
        public virtual File File { get; set; }
    }
}
