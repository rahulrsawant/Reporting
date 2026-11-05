using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Reporting.Domain.Entities;

namespace Reporting.Infrastructure.Persistence;

public partial class ReportingDbContext : DbContext
{
    public ReportingDbContext(DbContextOptions<ReportingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<AccountBalance> AccountBalances { get; set; }

    public virtual DbSet<AccountHolder> AccountHolders { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<Investor> Investors { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.ToTable("access");

            entity.HasIndex(e => e.Email, "UQ_access_email").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_access_username").IsUnique();

            entity.Property(e => e.AccessId).HasColumnName("accessid");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_access_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordhash");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AccountBalance>(entity =>
        {
            entity.ToTable("accountbalance");

            entity.HasIndex(e => e.InvestorId, "IX_accountbalance_investorid");

            entity.Property(e => e.AccountBalanceId).HasColumnName("accountbalanceid");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("accountbalance");
            entity.Property(e => e.AccountBalanceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("accountbalancecurrency");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_accountbalance_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.InvestorId).HasColumnName("investorid");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");

            entity.HasOne(d => d.Investor).WithMany(p => p.AccountBalances)
                .HasForeignKey(d => d.InvestorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_accountbalance_investor");
        });

        modelBuilder.Entity<AccountHolder>(entity =>
        {
            entity.ToTable("accountholder");

            entity.HasIndex(e => e.InvestorId, "IX_accountholder_investorid");

            entity.Property(e => e.AccountHolderId).HasColumnName("accountholderid");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(200)
                .HasColumnName("accountholdername");
            entity.Property(e => e.AccountHolderType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("accountholdertype");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_accountholder_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.InvestorId).HasColumnName("investorid");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");
            entity.Property(e => e.WithholdingPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("withholdingpercentage");

            entity.HasOne(d => d.Investor).WithMany(p => p.AccountHolders)
                .HasForeignKey(d => d.InvestorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_accountholder_investor");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.HasIndex(e => e.ClientCode, "UQ_client_clientcode").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("clientid");
            entity.Property(e => e.ClientCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientcode");
            entity.Property(e => e.ClientName)
                .HasMaxLength(200)
                .HasColumnName("clientname");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_client_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");
        });

        modelBuilder.Entity<Fund>(entity =>
        {
            entity.ToTable("fund");

            entity.HasIndex(e => e.ClientId, "IX_fund_clientid");

            entity.HasIndex(e => e.FundCode, "UQ_fund_fundcode").IsUnique();

            entity.Property(e => e.FundId).HasColumnName("fundid");
            entity.Property(e => e.ClientId).HasColumnName("clientid");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_fund_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.FundCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fundcode");
            entity.Property(e => e.FundCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("fundcurrency");
            entity.Property(e => e.FundDomicile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("funddomicile");
            entity.Property(e => e.FundName)
                .HasMaxLength(200)
                .HasColumnName("fundname");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");

            entity.HasOne(d => d.Client).WithMany(p => p.Funds)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fund_client");
        });

        modelBuilder.Entity<Investor>(entity =>
        {
            entity.ToTable("investor");

            entity.HasIndex(e => e.FundId, "IX_investor_fundid");

            entity.HasIndex(e => e.InvestorExternalId, "UQ_investor_investorexternalid").IsUnique();

            entity.Property(e => e.InvestorId).HasColumnName("investorid");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_investor_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.FundId).HasColumnName("fundid");
            entity.Property(e => e.InvestorDomicile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("investordomicile");
            entity.Property(e => e.InvestorExternalId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("investorexternalid");
            entity.Property(e => e.InvestorName)
                .HasMaxLength(200)
                .HasColumnName("investorname");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");

            entity.HasOne(d => d.Fund).WithMany(p => p.Investors)
                .HasForeignKey(d => d.FundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_investor_fund");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payment");

            entity.HasIndex(e => e.AccountBalanceId, "IX_payment_accountbalanceid");

            entity.Property(e => e.PaymentId).HasColumnName("paymentid");
            entity.Property(e => e.AccountBalanceId).HasColumnName("accountbalanceid");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())", "DF_payment_createdate")
                .HasColumnName("createdate");
            entity.Property(e => e.PaymentAmount)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("paymentamount");
            entity.Property(e => e.PaymentCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("paymentcurrency");
            entity.Property(e => e.UpdateDate).HasColumnName("updatedate");

            entity.HasOne(d => d.AccountBalance).WithMany(p => p.Payments)
                .HasForeignKey(d => d.AccountBalanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payment_accountbalance");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
