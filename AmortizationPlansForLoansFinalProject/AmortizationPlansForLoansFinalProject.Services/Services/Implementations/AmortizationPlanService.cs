using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services.Implementations
{
    public class AmortizationPlanService : IAmortizationPlanService
    {
        private readonly IAmortizationPlanRepository _repository;

        public AmortizationPlanService(IAmortizationPlanRepository repository)
        {
            _repository = repository;
        }

        public void CreateAmortizationPlan(LoanInputDto loanInputDto)
        {
            throw new NotImplementedException();
        }
    }
}