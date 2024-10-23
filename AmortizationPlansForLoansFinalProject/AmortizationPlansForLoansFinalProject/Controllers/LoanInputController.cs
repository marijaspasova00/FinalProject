using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using AmortizationPlansForLoansFinalProject.DTOs;
using AmortizationPlansForLoansFinalProject.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmortizationPlansForLoansFinalProject.Controllers
{
    public class LoanInputController : Controller
    {
        private readonly ILoanInputService _loanInputService;
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;


        public LoanInputController(ILoanInputService loanInputService, IProductService productService, IProductRepository productRepository)
        {
            _loanInputService = loanInputService;
            _productService = productService;
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new LoanInputDto
            {
                ProductList = _productService.GetAllProducts() 
            };
            return View(model);
        }

    }
}
