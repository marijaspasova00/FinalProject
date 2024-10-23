using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories
{
    public interface IAmortizationPlanRepository
    {
        Task AddAmPlanIntoDbAsync(AmortizationPlan amortizationPlan);
        Task AddAmPlanIntoDbListAsync(List<AmortizationPlan> amortizationPlans);

    }
}
