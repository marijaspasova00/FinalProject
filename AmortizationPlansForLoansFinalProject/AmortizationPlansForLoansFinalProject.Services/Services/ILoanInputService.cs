using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services
{
    public interface ILoanInputService
    {
        Task AddLoanInputAsync(LoanInput loanInput);
        Task<IEnumerable<AmortizationPlan>> GetAmortizationPlansByLoanInputAsync(LoanInput loanInput);
    }

}
