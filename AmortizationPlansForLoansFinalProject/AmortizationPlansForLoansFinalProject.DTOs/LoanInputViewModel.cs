using AmortizationPlansForLoansFinalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // For LINQ operations



namespace AmortizationPlansForLoansFinalProject.ViewModels
{
    public class LoanInputViewModel
    {
        public int ProductID { get; set; }        // Selected Product ID
        public decimal Amount { get; set; }       // Loan Amount
        public decimal InterestRate { get; set; }  // Interest Rate
        public int NoInstallments { get; set; }    // Number of Installments
        public PaymentFrequency SelectedFrequency { get; set; } // Payment Frequency
        public IEnumerable<System.Web.Mvc.SelectListItem> Products { get; set; } // Product options for dropdown
        public IEnumerable<System.Web.Mvc.SelectListItem> PaymentFrequencies { get; set; } // Dropdown options for Payment Frequency
    }
}
