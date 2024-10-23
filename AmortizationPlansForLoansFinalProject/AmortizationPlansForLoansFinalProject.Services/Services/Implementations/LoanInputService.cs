using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.DataAccess.Repositories.Implementations;
using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;
using AmortizationPlansForLoansFinalProject.Services.Services;

namespace AmortizationPlansForLoansFinalProject.Services
{
    public class LoanInputService : ILoanInputService
    {
        private readonly ILoanInputRepository _loanInputRepository;
        private readonly IAmortizationPlanRepository _amortizationPlanRepository;

        public LoanInputService(ILoanInputRepository loanInputRepository, IAmortizationPlanRepository amortizationPlanRepository)
        {
            _loanInputRepository = loanInputRepository;
            _amortizationPlanRepository = amortizationPlanRepository;
        }


        public void CreateLoanInput(LoanInputDto loanInputDto)
        {
            //ValidateInoutParam
            var loanInput = new LoanInput
            {
                ProductID = loanInputDto.ProductID,
                Principal = loanInputDto.Principal,
                InterestRate = loanInputDto.InterestRate,
                NumberOfInstallments = loanInputDto.NumberOfInstallments,
                PaymentFrequency = loanInputDto.PaymentFrequency,
                FirstInstallmentDate = loanInputDto.FirstInstallmentDate,
                AdminFee = loanInputDto.AdminFee
            };

            _loanInputRepository.AddLoanInputIntoDb(loanInput);
            var amortizationPlan = CalculateAmortizationPlan(loanInput);
            _amortizationPlanRepository.AddAmPlanIntoDb(amortizationPlan);
        }
        private AmortizationPlan CalculateAmortizationPlan(LoanInputDto loanInputDto)
        {
            var loanInput = new LoanInput
            {
                ProductID = loanInputDto.ProductID,
                Principal = loanInputDto.Principal,
                InterestRate = loanInputDto.InterestRate,
                NumberOfInstallments = loanInputDto.NumberOfInstallments,
                PaymentFrequency = loanInputDto.PaymentFrequency,
                FirstInstallmentDate = loanInputDto.FirstInstallmentDate,
                AdminFee = loanInputDto.AdminFee,
                ClosingDate = loanInputDto.ClosingDate
            };

            return CalculateAmortizationPlan(loanInput);
        }

        private AmortizationPlan CalculateAmortizationPlan(LoanInput loanInput)
        {
            var amortizationPlans = new List<AmortizationPlan>();
            decimal installmentAmount = 0;

            var amortizationPlan = new AmortizationPlan
            {
                LoanInputID = loanInput.LoanInputID,
                Product = loanInput.Product,
                TotalAmount = loanInput.Principal + loanInput.AdminFee,
                PaymentFrequency = loanInput.PaymentFrequency,
                NoInstallment = loanInput.NumberOfInstallments,
                Principal = loanInput.Principal,
                FirstInstallmentDate = loanInput.FirstInstallmentDate,
                DateFrom = loanInput.FirstInstallmentDate.Date,
                DateTo = loanInput.ClosingDate,
                ClosingDate = loanInput.ClosingDate,
            };

            for (int i = 1; i <= loanInput.NumberOfInstallments; i++)
            {
                amortizationPlan.Interest = 0;
                switch (loanInput.PaymentFrequency)
                {
                    case PaymentFrequency.Monthly:
                        installmentAmount = CalculateMonthlyPayment(loanInput.Principal, loanInput.InterestRate, i);
                        break;
                    case PaymentFrequency.Quarterly:
                        installmentAmount = CalculateQuarterlyPayment(loanInput.Principal, loanInput.InterestRate, i);
                        break;
                    case PaymentFrequency.Yearly:
                        installmentAmount = CalculateYearlyPayment(loanInput.Principal, loanInput.InterestRate);
                        break;
                    default:
                        throw new ArgumentException("Invalid payment frequency.");
                }

                amortizationPlan.Interest = (installmentAmount * i) - loanInput.Principal;
                amortizationPlans.Add(amortizationPlan);
            }
            return amortizationPlans;
        }

        AmortizationPlan ILoanInputService.CalculateAmortizationPlan(LoanInput loanInput)
        {
            throw new NotImplementedException();
        }

        public async Task CalculateByPF(int ud)
        {
            switch (ud)
            {
                case (int)Domain.Enums.PaymentFrequency.Monthly:
                    CalculateMonthlyPayment(1, 1, 1);
                    break;
            }

            CalculateAmortizationPlan()
        }

        private decimal CalculateMonthlyPayment(decimal principal, decimal annualRate, int totalPayments)
        {
            decimal monthlyRate = annualRate / 100 / 12;
            return principal * monthlyRate / (1 - (decimal)Math.Pow((double)(1 + monthlyRate), -totalPayments));
        }

        private decimal CalculateQuarterlyPayment(decimal principal, decimal annualRate, int totalPayments)
        {
            decimal quarterlyRate = annualRate / 100 / 4;
            return principal * quarterlyRate / (1 - (decimal)Math.Pow((double)(1 + quarterlyRate), -totalPayments));
        }

        private decimal CalculateYearlyPayment(decimal principal, decimal annualRate)
        {
            decimal yearlyRate = annualRate / 100;
            return principal * yearlyRate;
        }
    }
}
