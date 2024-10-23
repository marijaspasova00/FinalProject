using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services
{
    public interface ILoanInputService
    {
        void CreateLoanInput(LoanInputDto loanInputDto);
        AmortizationPlan CalculateAmortizationPlan(LoanInput loanInput);
    }

}
