using Api_SuperPoli.Helpers;
using Api_SuperPoli.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Api_SuperPoli.Core.ProductManager
{
    public interface IProductManager
    {
        
        Task<ResultHelper<IEnumerable<ProductFile>>> GetProductAsync();
        Task<ResultHelper<ProductFile>> GetByIdAsync(int id);
        Task<ResultHelper<Product>> CreateAsync(Product product);
        Task<ResultHelper<Product>> UpdateAsync(Product product, int id);
   
    }
}
