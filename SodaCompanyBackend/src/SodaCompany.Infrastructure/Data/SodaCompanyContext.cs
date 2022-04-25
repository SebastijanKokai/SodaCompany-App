using Microsoft.EntityFrameworkCore;
using SodaCompany.Core.Entities;
using SodaCompany.Infrastructure.Extensions;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Infrastructure.Data
{
    public partial class SodaCompanyContext : DbContext
    {
        public SodaCompanyContext()
        {
        }

        public SodaCompanyContext(DbContextOptions<SodaCompanyContext> options)
            : base(options)
        {
            if (Database.IsInMemory())
                this.PrefillData();
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<OrganizationalUnit> OrganizationalUnit { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductionOrder> ProductionOrder { get; set; }
        public virtual DbSet<ProductionOrderProduct> ProductionOrderProduct { get; set; }
        public virtual DbSet<ProductionPlan> ProductionPlan { get; set; }
        public virtual DbSet<ProductionPlanWorkProcedure> ProductionPlanWorkProcedure { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehousePart> WarehousePart { get; set; }
        public virtual DbSet<WorkProcedure> WorkProcedure { get; set; }
        public virtual DbSet<WorkProcedurePart> WorkProcedurePart { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Employee__F3DBC5729C9DD420")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeTypeId).HasColumnName("employeeTypeId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationalUnitId).HasColumnName("organizationalUnitId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK__Employee__employ__4D5F7D71");

                entity.HasOne(d => d.OrganizationalUnit)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.OrganizationalUnitId)
                    .HasConstraintName("FK__Employee__organi__4E53A1AA");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrganizationalUnit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductModelId).HasColumnName("productModelId");

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductModelId)
                    .HasConstraintName("FK__Product__product__6166761E");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("unit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ProductionOrder>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductionOrder)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Productio__creat__51300E55");
            });

            modelBuilder.Entity<ProductionOrderProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductionOrderId).HasColumnName("productionOrderId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductionOrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Productio__produ__65370702");

                entity.HasOne(d => d.ProductionOrder)
                    .WithMany(p => p.ProductionOrderProduct)
                    .HasForeignKey(d => d.ProductionOrderId)
                    .HasConstraintName("FK__Productio__produ__6442E2C9");
            });

            modelBuilder.Entity<ProductionPlan>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionDeadline)
                    .HasColumnName("productionDeadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductionOrderId).HasColumnName("productionOrderId");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductionPlan)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Productio__creat__540C7B00");

                entity.HasOne(d => d.ProductionOrder)
                    .WithMany(p => p.ProductionPlan)
                    .HasForeignKey(d => d.ProductionOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Productio__produ__55009F39");
            });

            modelBuilder.Entity<ProductionPlanWorkProcedure>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductionPlanId).HasColumnName("productionPlanId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkProcedureId).HasColumnName("workProcedureId");

                entity.HasOne(d => d.ProductionPlan)
                    .WithMany(p => p.ProductionPlanWorkProcedure)
                    .HasForeignKey(d => d.ProductionPlanId)
                    .HasConstraintName("FK__Productio__produ__6AEFE058");

                entity.HasOne(d => d.WorkProcedure)
                    .WithMany(p => p.ProductionPlanWorkProcedure)
                    .HasForeignKey(d => d.WorkProcedureId)
                    .HasConstraintName("FK__Productio__workP__6BE40491");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WarehousePart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartId).HasColumnName("partId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouseId");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.WarehousePart)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK__Warehouse__partI__5D95E53A");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.WarehousePart)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK__Warehouse__wareh__5E8A0973");
            });

            modelBuilder.Entity<WorkProcedure>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductionPrice)
                    .HasColumnName("productionPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WorkProcedure)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WorkProce__produ__681373AD");
            });

            modelBuilder.Entity<WorkProcedurePart>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartId).HasColumnName("partId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkProcedureId).HasColumnName("workProcedureId");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.WorkProcedurePart)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK__WorkProce__partI__6EC0713C");

                entity.HasOne(d => d.WorkProcedure)
                    .WithMany(p => p.WorkProcedurePart)
                    .HasForeignKey(d => d.WorkProcedureId)
                    .HasConstraintName("FK__WorkProce__workP__6FB49575");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
