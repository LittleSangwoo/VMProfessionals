using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class PayMethod
{
    public int IdPayMethod { get; set; }

    public string PayMethod1 { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
