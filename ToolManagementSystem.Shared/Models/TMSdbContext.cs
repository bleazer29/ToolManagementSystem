using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToolManagementSystem.Shared.Models
{
    public partial class TMSdbContext : DbContext
    {
        public TMSdbContext()
        {
        }

        public TMSdbContext(DbContextOptions<TMSdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Counterparty> Counterparty { get; set; }
        public virtual DbSet<Cycle> Cycle { get; set; }
        public virtual DbSet<CycleItem> CycleItem { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Nomenclature> Nomenclature { get; set; }
        public virtual DbSet<NomenclatureSpecificationUnit> NomenclatureSpecificationUnit { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDocument> OrderDocument { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderTool> OrderTool { get; set; }
        public virtual DbSet<OrderToolOperatingTime> OrderToolOperatingTime { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportHistory> ReportHistory { get; set; }
        public virtual DbSet<Right> Right { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<RolePermissionRight> RolePermissionRight { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }
        public virtual DbSet<Tool> Tool { get; set; }
        public virtual DbSet<ToolClassification> ToolClassification { get; set; }
        public virtual DbSet<ToolDocument> ToolDocument { get; set; }
        public virtual DbSet<ToolHistory> ToolHistory { get; set; }
        public virtual DbSet<ToolStatus> ToolStatus { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Well> Well { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderDocument> WorkOrderDocument { get; set; }
        public virtual DbSet<WorkOrderHistory> WorkOrderHistory { get; set; }
        public virtual DbSet<WorkOrderStatus> WorkOrderStatus { get; set; }
        public virtual DbSet<WorkOrderTool> WorkOrderTool { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = TMSdb; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.CounterpartyId);
            });

            modelBuilder.Entity<Counterparty>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Edrpou)
                    .HasColumnName("EDRPOU")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Cycle)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CycleItem>(entity =>
            {
                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.CycleItem)
                    .HasForeignKey(d => d.CycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Nomenclature>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NomenclatureSpecificationUnit>(entity =>
            {
                entity.HasOne(d => d.Nomenclature)
                    .WithMany(p => p.NomenclatureSpecificationUnit)
                    .HasForeignKey(d => d.NomenclatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Specification)
                    .WithMany(p => p.NomenclatureSpecificationUnit)
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.NomenclatureSpecificationUnit)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CounterpartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.OrderCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderStatus_OrderStatusIdId");

                entity.HasOne(d => d.ResponsibleUser)
                    .WithMany(p => p.OrderResponsibleUser)
                    .HasForeignKey(d => d.ResponsibleUserId);

                entity.HasOne(d => d.Well)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.WellId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDocument>(entity =>
            {
                entity.HasOne(d => d.Document)
                    .WithMany(p => p.OrderDocument)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDocument)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderHistory)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<OrderTool>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderTool)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.OrderTool)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderToolOperatingTime>(entity =>
            {
                entity.Property(e => e.Commentary).HasMaxLength(250);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.OrderToolOperatingTime)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderToolOperatingTime_User_UserId");

                entity.HasOne(d => d.OrderTool)
                    .WithMany(p => p.OrderToolOperatingTime)
                    .HasForeignKey(d => d.OrderToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ViewName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.ParentPermission)
                    .WithMany(p => p.InverseParentPermission)
                    .HasForeignKey(d => d.ParentPermissionId)
                    .HasConstraintName("FK_Permission_Permission");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.FillePath)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ReportHistory>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ReportHistory)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportHistory)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Right>(entity =>
            {
                entity.Property(e => e.Alias)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.RoleCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpdator)
                    .WithMany(p => p.RoleLastUpdator)
                    .HasForeignKey(d => d.LastUpdatorId);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.RolePermissionCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpdator)
                    .WithMany(p => p.RolePermissionLastUpdator)
                    .HasForeignKey(d => d.LastUpdatorId);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_Role");
            });

            modelBuilder.Entity<RolePermissionRight>(entity =>
            {
                entity.HasKey(e => e.RoleRightPermission);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.RolePermissionRightCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpdator)
                    .WithMany(p => p.RolePermissionRightLastUpdator)
                    .HasForeignKey(d => d.LastUpdatorId);

                entity.HasOne(d => d.Right)
                    .WithMany(p => p.RolePermissionRight)
                    .HasForeignKey(d => d.RightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermissionRight_Right");

                entity.HasOne(d => d.RolePermission)
                    .WithMany(p => p.RolePermissionRight)
                    .HasForeignKey(d => d.RolePermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermissionRight_RolePermission");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.PartNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SerialNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.VendorNum)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.CycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Nomenclature)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.NomenclatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToolClassification)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.ToolClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToolStatus)
                    .WithMany(p => p.Tool)
                    .HasForeignKey(d => d.ToolStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ToolClassification>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.ParentToolClassification)
                    .WithMany(p => p.InverseParentToolClassification)
                    .HasForeignKey(d => d.ParentToolClassificationId);
            });

            modelBuilder.Entity<ToolDocument>(entity =>
            {
                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ToolDocument)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.ToolDocument)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ToolHistory>(entity =>
            {
                entity.Property(e => e.Commentary)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ToolHistory)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.ToolHistory)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ToolStatus>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(250);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.InverseCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_User_Department");

                entity.HasOne(d => d.LastUpdator)
                    .WithMany(p => p.InverseLastUpdator)
                    .HasForeignKey(d => d.LastUpdatorId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.UserRoleCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LastUpdator)
                    .WithMany(p => p.UserRoleLastUpdator)
                    .HasForeignKey(d => d.LastUpdatorId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Well>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Well)
                    .HasForeignKey(d => d.CounterpartyId);
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.WorkOrderCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ResponsibleUser)
                    .WithMany(p => p.WorkOrderResponsibleUser)
                    .HasForeignKey(d => d.ResponsibleUserId)
                    .HasConstraintName("FK_WorkOrder_User_UserId");

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrder)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkOrderDocument>(entity =>
            {
                entity.HasOne(d => d.Document)
                    .WithMany(p => p.WorkOrderDocument)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderDocument)
                    .HasForeignKey(d => d.WorkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkOrderHistory>(entity =>
            {
                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.WorkOrderHistory)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderHistory)
                    .HasForeignKey(d => d.WorkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkOrderStatus)
                    .WithMany(p => p.WorkOrderHistory)
                    .HasForeignKey(d => d.WorkOrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkOrderStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<WorkOrderTool>(entity =>
            {
                entity.HasOne(d => d.Tool)
                    .WithMany(p => p.WorkOrderTool)
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderTool)
                    .HasForeignKey(d => d.WorkOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
