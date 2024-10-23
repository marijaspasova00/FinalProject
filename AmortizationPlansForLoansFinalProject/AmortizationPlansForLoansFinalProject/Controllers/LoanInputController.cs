using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AmortizationPlansForLoansFinalProject.ViewModels;
using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

public class LoanInputController : Controller
{
    private readonly AmPlanDbContext _context; // Make sure to replace with your actual DbContext

    public LoanInputController(AmPlanDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new LoanInputViewModel
        {
            Products = await _context.Products.Select(p => new SelectListItem
            {
                Value = p.ProductID.ToString(),
                Text = p.Name // Adjust according to your Product properties
            }).ToListAsync(),
            PaymentFrequencies = Enum.GetValues(typeof(PaymentFrequency))
                                      .Cast<PaymentFrequency>()
                                      .Select(pf => new SelectListItem
                                      {
                                          Value = ((int)pf).ToString(),
                                          Text = pf.ToString()
                                      }).ToList(),
            SelectedPaymentFrequency = (int)PaymentFrequency.Monthly // Default selection
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult CalculateAmortization(LoanInputViewModel model)
    {
        // Perform calculations based on the model data
        // You can return the results or the same view with updated data

        return RedirectToAction("Index"); // Adjust as needed
    }
}
