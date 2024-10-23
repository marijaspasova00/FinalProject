using AmortizationPlansForLoansFinalProject.Domain.Enums;
using AmortizationPlansForLoansFinalProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmortizationPlansForLoansFinalProject.DataAccess.DataContext
{
    public class AmPlanDbContext : DbContext
    {
        public AmPlanDbContext(DbContextOptions<AmPlanDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCondition> ProductConditions { get; set; }
        public DbSet<LoanInput> LoanInputs { get; set; }
        public DbSet<AmortizationPlan> AmortizationPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product to ProductCondition one-to-one 
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCondition)
                .WithOne(pc => pc.Product)
                .HasForeignKey<ProductCondition>(pc => pc.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // Product to LoanInput one-to-many 
            modelBuilder.Entity<Product>()
                .HasMany(p => p.LoanInputs)
                .WithOne(li => li.Product)
                .HasForeignKey(li => li.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // Product to AmortizationPlan one-to-many 
            modelBuilder.Entity<Product>()
                .HasMany(p => p.AmortizationPlans)
                .WithOne(ap => ap.Product)
                .HasForeignKey(ap => ap.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // LoanInput to AmortizationPlan one-to-many 
            modelBuilder.Entity<LoanInput>()
                .HasMany(li => li.AmortizationPlans)
                .WithOne(ap => ap.LoanInput)
                .HasForeignKey(ap => ap.LoanInputID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().HasData(
                 new Product { ProductID = 1, Code = "P001", Name = "Home Loan", Status = ProductStatus.Active },
                 new Product { ProductID = 2, Code = "P002", Name = "Agro Loan", Status = ProductStatus.Active },
                 new Product { ProductID = 3, Code = "P003", Name = "Auto Loan", Status = ProductStatus.Active },
                 new Product { ProductID = 4, Code = "P004", Name = "Education Loan", Status = ProductStatus.Active },
                 new Product { ProductID = 5, Code = "P005", Name = "Personal Loan", Status = ProductStatus.Active },
                 new Product { ProductID = 6, Code = "P006", Name = "Business Loan", Status = ProductStatus.Active }
            );

            modelBuilder.Entity<ProductCondition>().HasData(
                new ProductCondition { ProductConditionID = 1, ProductID = 1, Description = "Standard home financing", MinAmount = 10000, MaxAmount = 100000, MinInterestRate = 2, MaxInterestRate = 5.5m, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 0 },
                new ProductCondition { ProductConditionID = 2, ProductID = 2, Description = "Standard Agro loan", MinAmount = 10000, MaxAmount = 500000, MinInterestRate = 3, MaxInterestRate = 4.5m, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 1500 },
                new ProductCondition { ProductConditionID = 3, ProductID = 3, Description = "Financing for vehicles", MinAmount = 2000, MaxAmount = 50000, MinInterestRate = 2.5m, MaxInterestRate = 4.5m, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 2000 },
                new ProductCondition { ProductConditionID = 4, ProductID = 4, Description = "Loan for Education", MinAmount = 5000, MaxAmount = 15000, MinInterestRate = 2, MaxInterestRate = 3.5m, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 500 },
                new ProductCondition { ProductConditionID = 5, ProductID = 5, Description = "Unsecured personal loan", MinAmount = 1500, MaxAmount = 7000, MinInterestRate = 2, MaxInterestRate = 5.5m, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 600 },
                new ProductCondition { ProductConditionID = 6, ProductID = 6, Description = "Standard business loan", MinAmount = 30000, MaxAmount = 500000, MinInterestRate = 3.5m, MaxInterestRate = 7, MinNumberOfInstallments = 10, MaxNumberOfInstallments = 60, AdminFee = 3500 }
            );

        }
    }
}
