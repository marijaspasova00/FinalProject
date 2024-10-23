using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AmortizationPlansForLoansFinalProject.ViewModels;
using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.Services.Services.Implementations;
using AmortizationPlansForLoansFinalProject.Services.Services;

public class LoanInputController : Controller
{
    private readonly AmPlanDbContext _context;
    private readonly ILoanInputService _loanInputService;

    public LoanInputController(AmPlanDbContext context, ILoanInputService loanInputService)
    {
        _context = context;
        _loanInputService = loanInputService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new LoanInputViewModel
        {
            Products = await _context.Products.Select(p => new SelectListItem
            {
                Value = p.ProductID.ToString(),
                Text = p.Name
            }).ToListAsync(),
            PaymentFrequencies = Enum.GetValues(typeof(PaymentFrequency))
                                      .Cast<PaymentFrequency>()
                                      .Select(pf => new SelectListItem
                                      {
                                          Value = ((int)pf).ToString(),
                                          Text = pf.ToString()
                                      }).ToList(),
            SelectedPaymentFrequency = (int)PaymentFrequency.Monthly
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CalculateAmortization(LoanInputViewModel model)
    {
        var productCondition = await _context.Products
            .Include(p => p.ProductCondition)
            .Where(p => p.ProductID == model.SelectedProductId)
            .Select(p => p.ProductCondition)
            .FirstOrDefaultAsync();

        if (productCondition != null)
        {
            if (model.Amount < productCondition.MinAmount || model.Amount > productCondition.MaxAmount)
            {
                ModelState.AddModelError(nameof(model.Amount), $"Amount must be between {productCondition.MinAmount} and {productCondition.MaxAmount}.");
            }
            if (model.InterestRate < productCondition.MinInterestRate || model.InterestRate > productCondition.MaxInterestRate)
            {
                ModelState.AddModelError(nameof(model.InterestRate), $"Interest Rate must be between {productCondition.MinInterestRate} and {productCondition.MaxInterestRate}.");
            }
            if (model.NumberOfInstallments < productCondition.MinNumberOfInstallments || model.NumberOfInstallments > productCondition.MaxNumberOfInstallments)
            {
                ModelState.AddModelError(nameof(model.NumberOfInstallments), $"Number of Installments must be between {productCondition.MinNumberOfInstallments} and {productCondition.MaxNumberOfInstallments}.");
            }
        }
        if (!ModelState.IsValid)
        {
            // Reload dropdowns and return the view if validation fails
            model.Products = await _context.Products
                .Include(p => p.ProductCondition)
                .Select(p => new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.Name
                }).ToListAsync();

            model.PaymentFrequencies = Enum.GetValues(typeof(PaymentFrequency))
                                          .Cast<PaymentFrequency>()
                                          .Select(pf => new SelectListItem
                                          {
                                              Value = ((int)pf).ToString(),
                                              Text = pf.ToString()
                                          }).ToList();

            return View("Index", model);
        }

        // Calculate and save the loan input
        var loanInput = new LoanInput
        {
            ProductID = model.SelectedProductId,
            Principal = model.Amount,
            InterestRate = model.InterestRate,
            NumberOfInstallments = model.NumberOfInstallments,
            PaymentFrequency = (PaymentFrequency)model.SelectedPaymentFrequency,
            AdminFee = 0,
            FirstInstallmentDate = DateTime.Now,
            ClosingDate = DateTime.Now.AddMonths(model.NumberOfInstallments)
        };

        // Save the LoanInput to the database or process it
        await _loanInputService.AddLoanInputAsync(loanInput);

        // Generate the Amortization Plans
        var amortizationPlans = await _loanInputService.GetAmortizationPlansByLoanInputAsync(loanInput);

        // Assign the generated amortization plans to the ViewModel
        model.AmortizationPlans = amortizationPlans;

        // Return the view with updated data
        return View("Index", model);
    }

}
