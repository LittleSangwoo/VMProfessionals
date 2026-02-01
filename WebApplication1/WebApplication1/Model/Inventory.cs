using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Inventory
{
    public int IdInventory { get; set; }

    public string IdUser { get; set; } = null!;

    public string IdMachine { get; set; } = null!;

    public int Count { get; set; }

    public virtual VendingMachine IdMachineNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
