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
    public class AmortizationPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstallmentPlanID { get; set; } 
        public int LoanInputID { get; set; }     
        [ForeignKey("LoanInputID")]
        public LoanInput LoanInput { get; set; }
        public int ProductID { get; set; }         
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int NoInstallment { get; set; }
        public DateTime DateFrom { get; set; }     
        public DateTime DateTo { get; set; }       
        public DateTime PaymentDate { get; set; }  
        public decimal TotalAmount { get; set; }   
        public decimal Principal { get; set; }     
        public decimal Interest { get; set; }      
        public decimal RemainingAmount { get; set; }
        public decimal Expense { get; set; }        
        public DateTime FirstInstallmentDate { get; set; }
        public DateTime ClosingDate { get; set; }    
        public PaymentFrequency PaymentFrequency { get; set; }

    }

}

