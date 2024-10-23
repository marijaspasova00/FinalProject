using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories.Implementations
{
    public class ProductConditionRepository : IProductConditionRepository
    {
        private readonly AmPlanDbContext _context;

        public ProductConditionRepository(AmPlanDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCondition>> GetAllProductConditionsAsync()
        {
            return await _context.ProductConditions.ToListAsync();
        }

    }

}
