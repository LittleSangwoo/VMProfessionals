using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class VendingMachine
{
    public string IdMachine { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int IdModel { get; set; }

    public int IdType { get; set; }

    public string TotalIncome { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public string InventoryNumber { get; set; } = null!;

    public DateOnly ManufactureDate { get; set; }

    public DateOnly InstallDate { get; set; }

    public int ResourceMachine { get; set; }

    public int ServiceTime { get; set; }

    public int IdStatus { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<Checking> Checkings { get; set; } = new List<Checking>();

    public virtual ICollection<ContainProduct> ContainProducts { get; set; } = new List<ContainProduct>();

    public virtual Country IdCountryNavigation { get; set; } = null!;

    public virtual StatusesMachine IdStatusNavigation { get; set; } = null!;

    public virtual TypesMachine IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Maintenace> Maintenaces { get; set; } = new List<Maintenace>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
