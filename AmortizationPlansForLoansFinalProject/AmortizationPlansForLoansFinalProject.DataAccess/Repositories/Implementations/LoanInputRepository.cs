using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories
{
    public class LoanInputRepository : ILoanInputRepository
    {
        private readonly AmPlanDbContext _context;

        public LoanInputRepository(AmPlanDbContext context)
        {
            _context = context;
        }

        public async Task AddLoanInputIntoDbAsync(LoanInput loanInput)
        {
            await _context.LoanInputs.AddAsync(loanInput); 
            await _context.SaveChangesAsync();
        }
    }
}
