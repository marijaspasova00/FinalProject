using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmortizationPlansForLoansFinalProject.ViewModels
{
    public class LoanInputViewModel
    {
        public IEnumerable<SelectListItem> Products { get; set; } // List for products dropdown
        public int SelectedProductId { get; set; } // Store the selected product ID
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int NumberOfInstallments { get; set; }
        public int SelectedPaymentFrequency { get; set; } // Store the selected payment frequency
        public IEnumerable<SelectListItem> PaymentFrequencies { get; set; } // List for payment frequency dropdown
    }
}
