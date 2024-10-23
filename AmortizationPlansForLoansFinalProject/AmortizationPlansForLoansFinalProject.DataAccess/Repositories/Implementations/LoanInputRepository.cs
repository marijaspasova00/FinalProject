using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories.Implementations
{
    public class LoanInputRepository : ILoanInputRepository
    {
        private readonly AmPlanDbContext _context;

        public LoanInputRepository(AmPlanDbContext context)
        {
            _context = context;
        }

        public void AddLoanInputIntoDb(LoanInput loanInput)
        {
            _context.LoanInputs.Add(loanInput);
            _context.SaveChanges();
        }
        
    }
}
