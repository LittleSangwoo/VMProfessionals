using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class StatusesMachine
{
    public int IdStatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
