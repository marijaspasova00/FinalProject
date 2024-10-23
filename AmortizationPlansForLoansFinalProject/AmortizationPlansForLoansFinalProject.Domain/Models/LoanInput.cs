using AmortizationPlansForLoansFinalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Domain.Models
{
    public class LoanInput
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanInputID { get; set; }
        public int ProductID { get; set; } 
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public DateTime AgreementDate { get; set; }
        public decimal Principal { get; set; }
        public decimal InterestRate { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public decimal AdminFee { get; set; }
        public DateTime FirstInstallmentDate { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateTime ClosingDate { get; set; }
        public virtual ICollection<AmortizationPlan> AmortizationPlans { get; set; }
    }

}
