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
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public string Code { get; set; }  
        public string Name { get; set; }  
        public ProductStatus Status { get; set; }

        [ForeignKey("ProductConditionID")]
        public int ProductConditionID { get; set; }
        public ProductCondition ProductCondition { get; set; }

        [ForeignKey("LoanInputID")]
        public virtual ICollection<LoanInput> LoanInputs { get; set; }

        [ForeignKey("InstallmentPlanID")]
        public virtual ICollection<AmortizationPlan> AmortizationPlans { get; set; }
    }


}
