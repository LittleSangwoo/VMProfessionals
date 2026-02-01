using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Company
{
    public int IdCompany { get; set; }

    public string Company1 { get; set; } = null!;

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
}
