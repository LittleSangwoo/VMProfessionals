using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Checking
{
    public int IdCheck { get; set; }

    public DateOnly LastCheck { get; set; }

    public int Interval { get; set; }

    public DateOnly NextCheck { get; set; }

    public string IdMachine { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public virtual VendingMachine IdMachineNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
