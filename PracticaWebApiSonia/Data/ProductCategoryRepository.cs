using PracticaWebApiSonia.Interface;
using PracticaWebApiSonia.Model;
using Microsoft.EntityFrameworkCore;
using PracticaWebApiSonia.Data;

namespace PracticaWebApiSonia.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _contexto;

        public ProductCategoryRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _contexto.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _contexto.ProductCategories.FindAsync(id);
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            _contexto.ProductCategories.Add(productCategory);
            await _contexto.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory productCategory)
        {
            _contexto.ProductCategories.Update(productCategory);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productCategory = await _contexto.ProductCategories.FindAsync(id);
            if (productCategory != null)
            {
                _contexto.ProductCategories.Remove(productCategory);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}

