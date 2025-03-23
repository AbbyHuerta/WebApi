using System.Threading.Tasks;
using System.Collections.Generic;
using PracticaWebApiSonia.Model;

namespace PracticaWebApiSonia.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetByIdAsync(int id);
        Task AddAsync(ProductCategory productCategory);
        Task UpdateAsync(ProductCategory productCategory);
        Task DeleteAsync(int id);
    }
}
