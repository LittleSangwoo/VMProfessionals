using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Maintenace
{
    public int IdMaintenace { get; set; }

    public DateTime DateMaintenace { get; set; }

    public string? IssuesFound { get; set; }

    public string WorkDescription { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public string IdMachine { get; set; } = null!;

    public virtual VendingMachine IdMachineNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
