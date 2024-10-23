using AmortizationPlansForLoansFinalProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.Repositories
{
    public interface IProductConditionRepository
    {
        Task<IEnumerable<ProductCondition>> GetAllProductConditionsAsync();
    }
}
