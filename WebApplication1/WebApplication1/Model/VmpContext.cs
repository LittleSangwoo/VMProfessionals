using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public partial class VmpContext : DbContext
{
    public VmpContext()
    {
    }

    public VmpContext(DbContextOptions<VmpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Checking> Checkings { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ContainProduct> ContainProducts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Maintenace> Maintenaces { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<PayMethod> PayMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<StatusesMachine> StatusesMachines { get; set; }

    public virtual DbSet<TypesMachine> TypesMachines { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VendingMachine> VendingMachines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.IdBrand);

            entity.ToTable("brands");

            entity.Property(e => e.IdBrand)
                .ValueGeneratedNever()
                .HasColumnName("idBrand");
            entity.Property(e => e.Brand1)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Brands)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_brands_companies");
        });

        modelBuilder.Entity<Checking>(entity =>
        {
            entity.HasKey(e => e.IdCheck);

            entity.ToTable("checking");

            entity.Property(e => e.IdCheck)
                .ValueGeneratedNever()
                .HasColumnName("idCheck");
            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("idUser");
            entity.Property(e => e.Interval).HasColumnName("interval");
            entity.Property(e => e.LastCheck).HasColumnName("lastCheck");
            entity.Property(e => e.NextCheck).HasColumnName("nextCheck");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Checkings)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_checking_vendingMachines");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Checkings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_checking_users");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany);

            entity.ToTable("companies");

            entity.Property(e => e.IdCompany)
                .ValueGeneratedNever()
                .HasColumnName("idCompany");
            entity.Property(e => e.Company1)
                .HasMaxLength(50)
                .HasColumnName("company");
        });

        modelBuilder.Entity<ContainProduct>(entity =>
        {
            entity.HasKey(e => e.IdContain);

            entity.ToTable("containProducts");

            entity.Property(e => e.IdContain)
                .ValueGeneratedNever()
                .HasColumnName("idContain");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .HasColumnName("idProduct");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.ContainProducts)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_containProducts_vendingMachines");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ContainProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_containProducts_products");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry);

            entity.ToTable("countries");

            entity.Property(e => e.IdCountry)
                .ValueGeneratedNever()
                .HasColumnName("idCountry");
            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .HasColumnName("country");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.IdInventory);

            entity.ToTable("inventory");

            entity.Property(e => e.IdInventory)
                .ValueGeneratedNever()
                .HasColumnName("idInventory");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("idUser");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inventory_vendingMachines");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inventory_users");
        });

        modelBuilder.Entity<Maintenace>(entity =>
        {
            entity.HasKey(e => e.IdMaintenace);

            entity.ToTable("maintenace");

            entity.Property(e => e.IdMaintenace)
                .ValueGeneratedNever()
                .HasColumnName("idMaintenace");
            entity.Property(e => e.DateMaintenace).HasColumnName("dateMaintenace");
            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("idUser");
            entity.Property(e => e.IssuesFound)
                .HasMaxLength(50)
                .HasColumnName("issuesFound");
            entity.Property(e => e.WorkDescription)
                .HasMaxLength(50)
                .HasColumnName("workDescription");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Maintenaces)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maintenace_vendingMachines");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Maintenaces)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maintenace_users");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.IdModel);

            entity.ToTable("models");

            entity.Property(e => e.IdModel)
                .ValueGeneratedNever()
                .HasColumnName("idModel");
            entity.Property(e => e.IdBrand).HasColumnName("idBrand");
            entity.Property(e => e.Model1)
                .HasMaxLength(50)
                .HasColumnName("model");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Models)
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_models_brands");
        });

        modelBuilder.Entity<PayMethod>(entity =>
        {
            entity.HasKey(e => e.IdPayMethod);

            entity.ToTable("payMethods");

            entity.Property(e => e.IdPayMethod)
                .ValueGeneratedNever()
                .HasColumnName("idPayMethod");
            entity.Property(e => e.PayMethod1)
                .HasMaxLength(50)
                .HasColumnName("payMethod");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("products");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .HasColumnName("idProduct");
            entity.Property(e => e.AverageSale)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("averageSale");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.MinimalCount).HasColumnName("minimalCount");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("roles");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("idRole");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale);

            entity.ToTable("sales");

            entity.Property(e => e.IdSale)
                .ValueGeneratedNever()
                .HasColumnName("idSale");
            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdPaymentMethod).HasColumnName("idPaymentMethod");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .HasColumnName("idProduct");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Timestamp)
                .HasMaxLength(50)
                .HasColumnName("timestamp");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_vendingMachines");

            entity.HasOne(d => d.IdPaymentMethodNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_payMethods");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_products");
        });

        modelBuilder.Entity<StatusesMachine>(entity =>
        {
            entity.HasKey(e => e.IdStatus);

            entity.ToTable("statusesMachine");

            entity.Property(e => e.IdStatus)
                .ValueGeneratedNever()
                .HasColumnName("idStatus");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<TypesMachine>(entity =>
        {
            entity.HasKey(e => e.IdType);

            entity.ToTable("typesMachine");

            entity.Property(e => e.IdType)
                .ValueGeneratedNever()
                .HasColumnName("idType");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("users");

            entity.Property(e => e.IdUser)
                .HasMaxLength(50)
                .HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.IsEngineer).HasColumnName("isEngineer");
            entity.Property(e => e.IsManager).HasColumnName("isManager");
            entity.Property(e => e.IsOperator).HasColumnName("isOperator");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles");
        });

        modelBuilder.Entity<VendingMachine>(entity =>
        {
            entity.HasKey(e => e.IdMachine);

            entity.ToTable("vendingMachines");

            entity.Property(e => e.IdMachine)
                .HasMaxLength(50)
                .HasColumnName("idMachine");
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.IdModel).HasColumnName("idModel");
            entity.Property(e => e.IdStatus).HasColumnName("idStatus");
            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.InstallDate).HasColumnName("installDate");
            entity.Property(e => e.InventoryNumber)
                .HasMaxLength(50)
                .HasColumnName("inventoryNumber");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.ManufactureDate).HasColumnName("manufactureDate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ResourceMachine).HasColumnName("resourceMachine");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .HasColumnName("serialNumber");
            entity.Property(e => e.ServiceTime).HasColumnName("serviceTime");
            entity.Property(e => e.TotalIncome)
                .HasMaxLength(50)
                .HasColumnName("totalIncome");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendingMachines_countries");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendingMachines_statusesMachine");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vendingMachines_typesMachine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
