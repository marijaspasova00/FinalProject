using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmortizationPlansForLoansFinalProject.ViewModels
{
    public class LoanInputViewModel
    {
        public IEnumerable<SelectListItem> Products { get; set; } 
        public int SelectedProductId { get; set; } 
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int NumberOfInstallments { get; set; }
        public int SelectedPaymentFrequency { get; set; } 
        public IEnumerable<SelectListItem> PaymentFrequencies { get; set; } 

        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal MinInterestRate { get; set; }
        public decimal MaxInterestRate { get; set; }
        public int MinNumberOfInstallments { get; set; }
        public int MaxNumberOfInstallments { get; set; }

        public IEnumerable<AmortizationPlan> AmortizationPlans { get; set; }
    }
}
