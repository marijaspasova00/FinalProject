using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DTOs
{
    public class LoanInputDto
    {
        public int ProductID { get; set; }
        public decimal Principal { get; set; }
        public decimal InterestRate { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public decimal AdminFee { get; set; }
        public DateTime FirstInstallmentDate { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateTime AgreementDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
        public AmortizationPlan AmortizationPlan { get; set; }

    }
}
