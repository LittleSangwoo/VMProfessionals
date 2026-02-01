using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class TypesMachine
{
    public int IdType { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
