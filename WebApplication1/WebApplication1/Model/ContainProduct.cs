using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class ContainProduct
{
    public int IdContain { get; set; }

    public string IdProduct { get; set; } = null!;

    public string IdMachine { get; set; } = null!;

    public int Count { get; set; }

    public virtual VendingMachine IdMachineNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
