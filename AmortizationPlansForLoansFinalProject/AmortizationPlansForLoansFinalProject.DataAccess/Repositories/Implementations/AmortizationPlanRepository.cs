using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories.Implementations
{
    public class AmortizationPlanRepository(AmPlanDbContext context) : IAmortizationPlanRepository
    {
        public void AddAmPlanIntoDb(AmortizationPlan amortizationPlan)
        {
            //await context.AmortizationPlans.AddAsync(amortizationPlan);
            context.AmortizationPlans.AddRange(amortizationPlan);
            context.SaveChanges();
        }

    }
}
