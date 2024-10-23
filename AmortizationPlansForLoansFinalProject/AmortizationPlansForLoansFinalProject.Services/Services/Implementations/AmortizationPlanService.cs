using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services.Implementations
{
    public class AmortizationPlanService : IAmortizationPlanService
    {
        private readonly IAmortizationPlanRepository _amortizationPlanRepository;

        public AmortizationPlanService(IAmortizationPlanRepository amortizationPlanRepository)
        {
            _amortizationPlanRepository = amortizationPlanRepository;
        }

        public async Task AddAmortizationPlanAsync(AmortizationPlan amortizationPlan)
        {
            await _amortizationPlanRepository.AddAmPlanIntoDbAsync(amortizationPlan);
        }

        public async Task AddAmortizationPlansAsync(List<AmortizationPlan> amortizationPlans)
        {
            await _amortizationPlanRepository.AddAmPlanIntoDbListAsync(amortizationPlans);
        }
    }
}