using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using AmortizationPlansForLoansFinalProject.DataAccess.Repositories;
using AmortizationPlansForLoansFinalProject.DataAccess.Repositories.Implementations;
using AmortizationPlansForLoansFinalProject.Services;
using AmortizationPlansForLoansFinalProject.Services.Services;
using AmortizationPlansForLoansFinalProject.Services.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AmortizationPlansForLoansFinalProject.Helper
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AmPlanDbContext>(options =>
            options.UseSqlServer(@"Data Source=(localdb)\SEDCLocalDb;Database=AmPlansFinalProject;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        }
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILoanInputRepository, LoanInputRepository>();
            services.AddScoped<IAmortizationPlanRepository, AmortizationPlanRepository>();

        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILoanInputService, LoanInputService>();
            services.AddScoped<IAmortizationPlanService, AmortizationPlanService>();
        }
    }

}