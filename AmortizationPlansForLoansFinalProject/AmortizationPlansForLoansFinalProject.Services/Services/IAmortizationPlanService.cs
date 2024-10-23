using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services
{
    public interface IAmortizationPlanService
    {
        Task AddAmortizationPlanAsync(AmortizationPlan amortizationPlan);
        Task AddAmortizationPlansAsync(List<AmortizationPlan> amortizationPlans);
    }
}
