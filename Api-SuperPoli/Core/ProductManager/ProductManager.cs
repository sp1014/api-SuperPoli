using Api_SuperPoli;
using Api_SuperPoli.Helpers;
using Api_SuperPoli.Models;
using Api_SuperPoli.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api_SuperPoli.Core.ProductManager
{
   

    public class ProductManager : IProductManager
    {
        private readonly UsersContext _context;

        public ProductManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_LIST = "There is no user at this time";
        public async Task<ResultHelper<IEnumerable<ProductFile>>> GetProductAsync()
        {
            var resultado = new ResultHelper<IEnumerable<ProductFile>>();
       
            var nots = await _context.ProductFiles.Include(s => s.Product).Include(s=>s.File).ToListAsync();

            if (nots.Count > 0)
            {
                resultado.Value = nots;
            }
            else
            {
                string error = _ERROR_LIST;
                resultado.AddError(error);
            }
            return resultado;
        }
        public async Task<ResultHelper<ProductFile>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<ProductFile>();
            var nots = await _context.ProductFiles.Include(s => s.Product).Include(s => s.File).FirstOrDefaultAsync(s => s.ProductId == id) ;
            if (nots != null)
            {
                resultado.Value = nots;
            }
            else
            {
                string error = _ERROR_USER;
                resultado.AddError(error);
            }
            return resultado;
        }
        
        public async Task<ResultHelper<Product>> CreateAsync(Product product)
        {
            var resultado = new ResultHelper<Product>();
           try
            {
                Product datanew = new Product

                {
                    Activo = product.Activo,
                    NameProduct = product.NameProduct,
                    Price = product.Price,
                    Descriptions = product.Descriptions,
                    Quantity = product.Quantity,
                    promotion= product.promotion,
                    ProductFile = product.IdFile.Select(fileId => new ProductFile { FileId = fileId }).ToList()

                };            

                    _context.Products.Add(datanew);
                    await _context.SaveChangesAsync();
                    resultado.Value = datanew;
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        
        public async Task<ResultHelper<Product>> UpdateAsync(Product product, int id)
        {
            var resultado = new ResultHelper<Product>();
            try
            {
                if (id == product.Id)
                {
                    Product datanew = new Product

                    {
                        Id = product.Id,
                        Activo = product.Activo,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        Descriptions = product.Descriptions,
                        Quantity = product.Quantity,
                        promotion = product.promotion,
                        ProductFile = product.IdFile.Select(fileId => new ProductFile { FileId = fileId }).ToList()

                    };
                    _context.Entry(datanew).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    resultado.Value = datanew;
                }
                else
                {
                    resultado.AddError("El id no coincide con el id del REGISTRO");
                }
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }
        
   
     
    }
    }
