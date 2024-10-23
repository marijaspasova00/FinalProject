using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories
{
    public class AmortizationPlanRepository : IAmortizationPlanRepository
    {
        private readonly AmPlanDbContext _context;

        public AmortizationPlanRepository(AmPlanDbContext context)
        {
            _context = context;
        }

        public async Task AddAmPlanIntoDbAsync(AmortizationPlan amortizationPlan)
        {
            await _context.AmortizationPlans.AddAsync(amortizationPlan);
            await _context.SaveChangesAsync();
        }

        public async Task AddAmPlanIntoDbListAsync(List<AmortizationPlan> amortizationPlans)
        {
            await _context.AmortizationPlans.AddRangeAsync(amortizationPlans);
            await _context.SaveChangesAsync(); 
        }
        public async Task<AmortizationPlan> GetAmortizationPlanByLoanInputIdAsync(int loanInputId)
        {
            return await _context.AmortizationPlans
                .FirstOrDefaultAsync(ap => ap.LoanInputID == loanInputId);
        }
    }
}
