using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Data
{
    public partial class rupert_investmentsContext : DbContext
    {
        public rupert_investmentsContext()
        {
        }

        public rupert_investmentsContext(DbContextOptions<rupert_investmentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addressee> Addressees { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Deadline> Deadlines { get; set; }
        public virtual DbSet<Intermediary> Intermediaries { get; set; }
        public virtual DbSet<Lender> Lenders { get; set; }
        public virtual DbSet<LenderBorrower> LenderBorrowers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanRequest> LoanRequests { get; set; }
        public virtual DbSet<Repayment> Repayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=rupert_investments;Persist Security Info=False;User ID=sa;Password=reallyStrongPwd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Addressee>(entity =>
            {
                entity.ToTable("Addressee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.ToTable("Borrower");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddresseeId).HasColumnName("AddresseeID");
            });

            modelBuilder.Entity<Deadline>(entity =>
            {
                entity.HasKey(e => e.AgreedDate)
                    .HasName("PK__Deadline__E3698EBDCF807A01")
                    .IsClustered(false);

                entity.ToTable("Deadline");

                entity.Property(e => e.AgreedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Agreed_Date");
            });

            modelBuilder.Entity<Intermediary>(entity =>
            {
                entity.ToTable("Intermediary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddresseeId).HasColumnName("AddresseeID");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.HasOne(d => d.Addressee)
                    .WithMany(p => p.Intermediaries)
                    .HasForeignKey(d => d.AddresseeId)
                    .HasConstraintName("FK__Intermedi__Addre__628FA481");

                entity.HasOne(d => d.LoanDateNavigation)
                    .WithMany(p => p.Intermediaries)
                    .HasForeignKey(d => d.LoanDate)
                    .HasConstraintName("FK__Intermedi__LoanD__6383C8BA");
            });

            modelBuilder.Entity<Lender>(entity =>
            {
                entity.ToTable("Lender");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddresseeId).HasColumnName("AddresseeID");

                entity.HasOne(d => d.Addressee)
                    .WithMany(p => p.Lenders)
                    .HasForeignKey(d => d.AddresseeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lender__Addresse__45F365D3");
            });

            modelBuilder.Entity<LenderBorrower>(entity =>
            {
                entity.HasKey(e => new { e.BorrowerId, e.LenderId })
                    .HasName("PK__Lender_B__FF6D3E735473AA3E");

                entity.ToTable("Lender_Borrower");

                entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");

                entity.Property(e => e.LenderId).HasColumnName("LenderID");

                entity.Property(e => e.LoanDate).HasColumnType("datetime");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.LenderBorrowers)
                    .HasForeignKey(d => d.BorrowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lender_Bo__Borro__48CFD27E");

                entity.HasOne(d => d.Lender)
                    .WithMany(p => p.LenderBorrowers)
                    .HasForeignKey(d => d.LenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lender_Bo__Lende__49C3F6B7");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Loan__77387D07A0DDD6A5")
                    .IsClustered(false);

                entity.ToTable("Loan");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DeadlineAgreedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DeadlineAgreed_Date");

                entity.Property(e => e.RepaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.DeadlineAgreedDateNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.DeadlineAgreedDate)
                    .HasConstraintName("FK__Loan__DeadlineAg__5EBF139D");

                entity.HasOne(d => d.RepaymentDateNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.RepaymentDate)
                    .HasConstraintName("FK__Loan__RepaymentD__5FB337D6");
            });

            modelBuilder.Entity<LoanRequest>(entity =>
            {
                entity.ToTable("LoanRequest");

                entity.Property(e => e.LoanRequestId).HasColumnName("LoanRequestID");

                entity.Property(e => e.Amount).HasColumnType("numeric(19, 0)");

                entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Payday).HasColumnType("datetime");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.LoanRequests)
                    .HasForeignKey(d => d.BorrowerId)
                    .HasConstraintName("FK__LoanReque__Borro__3D5E1FD2");
            });

            modelBuilder.Entity<Repayment>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__Repaymen__77387D07B8952348")
                    .IsClustered(false);

                entity.ToTable("Repayment");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
