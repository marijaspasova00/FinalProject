using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.Domain.Models
{
    public class ProductCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductConditionID { get; set; } 
        public int ProductID { get; set; } 
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public string Description { get; set; }     
        public decimal MinAmount { get; set; }      
        public decimal MaxAmount { get; set; }      
        public decimal MinInterestRate { get; set; }
        public decimal MaxInterestRate { get; set; }
        public int MinNumberOfInstallments { get; set; } 
        public int MaxNumberOfInstallments { get; set; } 
        public decimal AdminFee { get; set; }      
    }

}
