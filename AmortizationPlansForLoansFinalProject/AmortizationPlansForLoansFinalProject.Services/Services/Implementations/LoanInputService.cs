using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Services.Services.Implementations
{
    public class LoanInputService : ILoanInputService
    {
        private readonly ILoanInputRepository _loanInputRepository;
        private readonly IAmortizationPlanRepository _amortizationPlanRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductConditionRepository _productConditionRepository;

        public LoanInputService(
            ILoanInputRepository loanInputRepository,
            IAmortizationPlanRepository amortizationPlanRepository,
            IProductRepository productRepository,
            IProductConditionRepository productConditionRepository)
        {
            _loanInputRepository = loanInputRepository;
            _amortizationPlanRepository = amortizationPlanRepository;
            _productRepository = productRepository;
            _productConditionRepository = productConditionRepository;
        }

        public async Task AddLoanInputAsync(LoanInput loanInput)
        {
            await ValidateLoanInput(loanInput);
            await _loanInputRepository.AddLoanInputIntoDbAsync(loanInput);

            var amortizationPlan = CalculateAmortizationPlan(loanInput);
            await _amortizationPlanRepository.AddAmPlanIntoDbAsync(amortizationPlan);
        }

        private async Task ValidateLoanInput(LoanInput loanInput)
        {
            var productConditions = await _productConditionRepository.GetAllProductConditionsAsync();
            var productCondition = productConditions.FirstOrDefault(pc => pc.ProductID == loanInput.ProductID);

            if (productCondition == null)
            {
                throw new ArgumentException("Invalid product ID or no conditions found for this product.");
            }

            if (loanInput.Principal < productCondition.MinAmount || loanInput.Principal > productCondition.MaxAmount)
            {
                throw new ArgumentException($"Principal amount must be between {productCondition.MinAmount} and {productCondition.MaxAmount}.");
            }

            if (loanInput.InterestRate < productCondition.MinInterestRate || loanInput.InterestRate > productCondition.MaxInterestRate)
            {
                throw new ArgumentException($"Interest rate must be between {productCondition.MinInterestRate} and {productCondition.MaxInterestRate}.");
            }

            if (loanInput.NumberOfInstallments < productCondition.MinNumberOfInstallments || loanInput.NumberOfInstallments > productCondition.MaxNumberOfInstallments)
            {
                throw new ArgumentException($"Number of installments must be between {productCondition.MinNumberOfInstallments} and {productCondition.MaxNumberOfInstallments}.");
            }

            if (loanInput.AdminFee < productCondition.AdminFee)
            {
                throw new ArgumentException($"Admin fee must be at least {productCondition.AdminFee}.");
            }
        }

        private AmortizationPlan CalculateAmortizationPlan(LoanInput loanInput)
        {
            var amortizationPlan = new AmortizationPlan
            {
                LoanInputID = loanInput.LoanInputID,
                TotalAmount = loanInput.Principal + loanInput.AdminFee,
                PaymentFrequency = loanInput.PaymentFrequency,
                NoInstallment = loanInput.NumberOfInstallments,
                Principal = loanInput.Principal,
                FirstInstallmentDate = loanInput.FirstInstallmentDate,
                DateFrom = loanInput.FirstInstallmentDate.Date,
                DateTo = loanInput.ClosingDate,
                ClosingDate = loanInput.ClosingDate,
                Installments = new List<decimal>() // Initialize the Installments list
            };

            for (int i = 1; i <= loanInput.NumberOfInstallments; i++)
            {
                decimal installmentAmount = 0;
                switch (loanInput.PaymentFrequency)
                {
                    case PaymentFrequency.Monthly:
                        installmentAmount = CalculateMonthlyPayment(loanInput.Principal, loanInput.InterestRate, loanInput.NumberOfInstallments);
                        break;
                    case PaymentFrequency.Quarterly:
                        installmentAmount = CalculateQuarterlyPayment(loanInput.Principal, loanInput.InterestRate, loanInput.NumberOfInstallments);
                        break;
                    case PaymentFrequency.Yearly:
                        installmentAmount = CalculateYearlyPayment(loanInput.Principal, loanInput.InterestRate);
                        break;
                    default:
                        throw new ArgumentException("Invalid payment frequency.");
                }

                amortizationPlan.Installments.Add(installmentAmount); // Add installment amount to the list
            }

            amortizationPlan.Interest = amortizationPlan.Installments.Sum() - loanInput.Principal; // Calculate total interest paid
            return amortizationPlan;
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
        public async Task<IEnumerable<AmortizationPlan>> GetAmortizationPlansByLoanInputAsync(LoanInput loanInput)
        {
            // Logic to generate amortization plans based on the LoanInput
            var amortizationPlans = new List<AmortizationPlan>();

            // Your logic to fill the amortizationPlans list

            return await Task.FromResult(amortizationPlans);
        }
    }
}
