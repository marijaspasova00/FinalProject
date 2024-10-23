using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;

namespace AmortizationPlansForLoansFinalProject.Mappers
{
    public class LoanInputMapper
    {
        public static LoanInput MapToLoanInput(LoanInputDto loanInputDto)
        {
            return new LoanInput
            {
                ProductID = loanInputDto.ProductID,
                Principal = loanInputDto.Principal,
                InterestRate = loanInputDto.InterestRate,
                NumberOfInstallments = loanInputDto.NumberOfInstallments,
                PaymentFrequency = loanInputDto.PaymentFrequency,
                AdminFee = 0, 
                FirstInstallmentDate = DateTime.Now,
                AgreementDate = DateTime.Now, 
                ClosingDate = DateTime.Now.AddYears(1) 
            };
        }
    }
}
