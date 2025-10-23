using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SunTrack.API.Data.Models;

public partial class SunTrackContext : DbContext
{
    public SunTrackContext()
    {
    }

    public SunTrackContext(DbContextOptions<SunTrackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FinancialStatus> FinancialStatuses { get; set; }

    public virtual DbSet<InstallationStatus> InstallationStatuses { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    public virtual DbSet<LeadDetail> LeadDetails { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectProductMapping> ProjectProductMappings { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GOPIRAJ;Database=SunTrack;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC078EBFD023");

            entity.ToTable("Address");

            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Pincode).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Address_CustomerId");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC073390DD4B");

            entity.ToTable("Customer");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .HasColumnName("Email_Id");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CustomerCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Customer_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CustomerUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_Customer_UpdatedBy");
        });

        modelBuilder.Entity<FinancialStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3214EC0753795742");

            entity.ToTable("Financial_Status");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApprovedRejected).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.ProjectDate)
                .HasColumnType("datetime")
                .HasColumnName("Project_Date");
            entity.Property(e => e.ProjectId).HasColumnName("Project_Id");
            entity.Property(e => e.PurchaseInvoice).HasColumnName("Purchase_Invoice");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.FinancialStatusCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FinancialStatus_CreatedBy");

            entity.HasOne(d => d.Customer).WithMany(p => p.FinancialStatuses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FinancialStatus_CustomerId");

            entity.HasOne(d => d.Project).WithMany(p => p.FinancialStatuses)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FinancialStatus_ProjectId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.FinancialStatusUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_FinancialStatus_UpdatedBy");
        });

        modelBuilder.Entity<InstallationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Installa__3214EC07E8D8445E");

            entity.ToTable("Installation_Status");

            entity.Property(e => e.Accable)
                .HasMaxLength(50)
                .HasColumnName("ACCable");
            entity.Property(e => e.AcdbAndDcdb)
                .HasMaxLength(50)
                .HasColumnName("ACDB_And_DCDB");
            entity.Property(e => e.CivilWorks)
                .HasMaxLength(50)
                .HasColumnName("Civil_Works");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.Dccable)
                .HasMaxLength(50)
                .HasColumnName("DCCable");
            entity.Property(e => e.Earthing).HasMaxLength(50);
            entity.Property(e => e.InverterMounting)
                .HasMaxLength(50)
                .HasColumnName("Inverter_Mounting");
            entity.Property(e => e.LightArrester)
                .HasMaxLength(50)
                .HasColumnName("Light_Arrester");
            entity.Property(e => e.NetMeter)
                .HasMaxLength(50)
                .HasColumnName("Net_Meter");
            entity.Property(e => e.PanelFixing)
                .HasMaxLength(50)
                .HasColumnName("Panel_Fixing");
            entity.Property(e => e.ProjectId).HasColumnName("Project_Id");
            entity.Property(e => e.StructureMounting)
                .HasMaxLength(50)
                .HasColumnName("Structure_Mounting");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InstallationStatusCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_InstallationStatus_CreatedBy");

            entity.HasOne(d => d.Customer).WithMany(p => p.InstallationStatuses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_InstallationStatus_CustomerId");

            entity.HasOne(d => d.Project).WithMany(p => p.InstallationStatuses)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_InstallationStatus_ProjectId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InstallationStatusUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_InstallationStatus_UpdatedBy");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lead__3214EC071AFFD0B7");

            entity.ToTable("Lead");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.FollowUpDate)
                .HasColumnType("datetime")
                .HasColumnName("Follow_Up_Date");
            entity.Property(e => e.LeadNo).HasMaxLength(100);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LeadCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lead_CreatedBy");

            entity.HasOne(d => d.Customer).WithMany(p => p.Leads)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lead_CustomerId");

            entity.HasOne(d => d.Resposible).WithMany(p => p.LeadResposibles)
                .HasForeignKey(d => d.ResposibleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lead_UserId");

            entity.HasOne(d => d.Status).WithMany(p => p.Leads)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lead_StatusId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.LeadUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_Lead_UpdatedBy");
        });

        modelBuilder.Entity<LeadDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lead_Det__3214EC0786F61BAB");

            entity.ToTable("Lead_Details");

            entity.Property(e => e.SiteVisitSchedule)
                .HasColumnType("datetime")
                .HasColumnName("SiteVisit_Schedule");
            entity.Property(e => e.SitevisitPhotos)
                .HasMaxLength(100)
                .HasColumnName("Sitevisit_Photos");
            entity.Property(e => e.SitevisitStatus)
                .HasMaxLength(100)
                .HasColumnName("Sitevisit_Status");

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadDetails)
                .HasForeignKey(d => d.LeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_LeadDetails_LeadId");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3214EC07C3D29088");

            entity.ToTable("Product_Details");

            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.CapacityUnits).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.QuantityUnits).HasMaxLength(100);
            entity.Property(e => e.SerialNo).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ProductDetails_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_ProductDetails_UpdatedBy");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC076F1E0495");

            entity.ToTable("Project");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.LeadId).HasColumnName("Lead_Id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("Project_Name");
            entity.Property(e => e.ServiceNo).HasColumnName("Service_No");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProjectCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_CreatedBy");

            entity.HasOne(d => d.Customer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_CustomerId");

            entity.HasOne(d => d.Lead).WithMany(p => p.Projects)
                .HasForeignKey(d => d.LeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_LeadId");

            entity.HasOne(d => d.SiteLocationNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SiteLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_SiteLocation");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Project_StatusId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProjectUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_Project_UpdatedBy");
        });

        modelBuilder.Entity<ProjectProductMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectP__3214EC07265AC094");

            entity.ToTable("ProjectProductMapping");

            entity.HasOne(d => d.Product).WithMany(p => p.ProjectProductMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ProjectProductMapping_ProductId");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectProductMappings)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ProjectProductMapping_ProjectId");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC071C9CE5F7");

            entity.ToTable("Status");

            entity.Property(e => e.ScreenName).HasMaxLength(50);
            entity.Property(e => e.StatusType).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0794EA9668");

            entity.ToTable("User");

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E387B1A0EE0").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D105343DA1105C").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
