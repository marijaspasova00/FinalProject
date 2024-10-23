﻿// <auto-generated />
using System;
using AmortizationPlansForLoansFinalProject.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmortizationPlansForLoansFinalProject.DataAccess.Migrations
{
    [DbContext(typeof(AmPlanDbContext))]
    [Migration("20241016205455_initAddedSeedData")]
    partial class initAddedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.AmortizationPlan", b =>
                {
                    b.Property<int>("InstallmentPlanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstallmentPlanID"));

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Expense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FirstInstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LoanInputID")
                        .HasColumnType("int");

                    b.Property<int>("NoInstallment")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentFrequency")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("RemainingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InstallmentPlanID");

                    b.HasIndex("LoanInputID");

                    b.HasIndex("ProductID");

                    b.ToTable("AmortizationPlans");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.LoanInput", b =>
                {
                    b.Property<int>("LoanInputID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanInputID"));

                    b.Property<decimal>("AdminFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("AgreementDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstInstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberOfInstallments")
                        .HasColumnType("int");

                    b.Property<int>("PaymentFrequency")
                        .HasColumnType("int");

                    b.Property<decimal>("Principal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("LoanInputID");

                    b.HasIndex("ProductID");

                    b.ToTable("LoanInputs");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductConditionID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Code = "P001",
                            Name = "Home Loan",
                            ProductConditionID = 0,
                            Status = 0
                        },
                        new
                        {
                            ProductID = 2,
                            Code = "P002",
                            Name = "Agro Loan",
                            ProductConditionID = 0,
                            Status = 0
                        },
                        new
                        {
                            ProductID = 3,
                            Code = "P003",
                            Name = "Auto Loan",
                            ProductConditionID = 0,
                            Status = 0
                        },
                        new
                        {
                            ProductID = 4,
                            Code = "P004",
                            Name = "Education Loan",
                            ProductConditionID = 0,
                            Status = 0
                        },
                        new
                        {
                            ProductID = 5,
                            Code = "P005",
                            Name = "Personal Loan",
                            ProductConditionID = 0,
                            Status = 0
                        },
                        new
                        {
                            ProductID = 6,
                            Code = "P006",
                            Name = "Business Loan",
                            ProductConditionID = 0,
                            Status = 0
                        });
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.ProductCondition", b =>
                {
                    b.Property<int>("ProductConditionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductConditionID"));

                    b.Property<decimal>("AdminFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaxNumberOfInstallments")
                        .HasColumnType("int");

                    b.Property<decimal>("MinAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MinNumberOfInstallments")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductConditionID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("ProductConditions");

                    b.HasData(
                        new
                        {
                            ProductConditionID = 1,
                            AdminFee = 0m,
                            Description = "Standard home financing",
                            MaxAmount = 100000m,
                            MaxInterestRate = 5.5m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 10000m,
                            MinInterestRate = 2m,
                            MinNumberOfInstallments = 10,
                            ProductID = 1
                        },
                        new
                        {
                            ProductConditionID = 2,
                            AdminFee = 1500m,
                            Description = "Standard Agro loan",
                            MaxAmount = 500000m,
                            MaxInterestRate = 4.5m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 10000m,
                            MinInterestRate = 3m,
                            MinNumberOfInstallments = 10,
                            ProductID = 2
                        },
                        new
                        {
                            ProductConditionID = 3,
                            AdminFee = 2000m,
                            Description = "Financing for vehicles",
                            MaxAmount = 50000m,
                            MaxInterestRate = 4.5m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 2000m,
                            MinInterestRate = 2.5m,
                            MinNumberOfInstallments = 10,
                            ProductID = 3
                        },
                        new
                        {
                            ProductConditionID = 4,
                            AdminFee = 500m,
                            Description = "Loan for Education",
                            MaxAmount = 15000m,
                            MaxInterestRate = 3.5m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 5000m,
                            MinInterestRate = 2m,
                            MinNumberOfInstallments = 10,
                            ProductID = 4
                        },
                        new
                        {
                            ProductConditionID = 5,
                            AdminFee = 600m,
                            Description = "Unsecured personal loan",
                            MaxAmount = 7000m,
                            MaxInterestRate = 5.5m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 1500m,
                            MinInterestRate = 2m,
                            MinNumberOfInstallments = 10,
                            ProductID = 5
                        },
                        new
                        {
                            ProductConditionID = 6,
                            AdminFee = 3500m,
                            Description = "Standard business loan",
                            MaxAmount = 500000m,
                            MaxInterestRate = 7m,
                            MaxNumberOfInstallments = 60,
                            MinAmount = 30000m,
                            MinInterestRate = 3.5m,
                            MinNumberOfInstallments = 10,
                            ProductID = 6
                        });
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.AmortizationPlan", b =>
                {
                    b.HasOne("AmortizationPlansForLoansFinalProject.Domain.Models.LoanInput", "LoanInput")
                        .WithMany("AmortizationPlans")
                        .HasForeignKey("LoanInputID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AmortizationPlansForLoansFinalProject.Domain.Models.Product", "Product")
                        .WithMany("AmortizationPlans")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LoanInput");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.LoanInput", b =>
                {
                    b.HasOne("AmortizationPlansForLoansFinalProject.Domain.Models.Product", "Product")
                        .WithMany("LoanInputs")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.ProductCondition", b =>
                {
                    b.HasOne("AmortizationPlansForLoansFinalProject.Domain.Models.Product", "Product")
                        .WithOne("ProductCondition")
                        .HasForeignKey("AmortizationPlansForLoansFinalProject.Domain.Models.ProductCondition", "ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.LoanInput", b =>
                {
                    b.Navigation("AmortizationPlans");
                });

            modelBuilder.Entity("AmortizationPlansForLoansFinalProject.Domain.Models.Product", b =>
                {
                    b.Navigation("AmortizationPlans");

                    b.Navigation("LoanInputs");

                    b.Navigation("ProductCondition")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}