using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AmPlanDbContext _context;

        public ProductRepository(AmPlanDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync(); 
        }
    }
}
