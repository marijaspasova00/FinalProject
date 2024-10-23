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
    [Migration("20241016205352_initAgain")]
    partial class initAgain
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
