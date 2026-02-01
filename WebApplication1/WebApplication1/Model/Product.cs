using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int MinimalCount { get; set; }

    public decimal AverageSale { get; set; }

    public virtual ICollection<ContainProduct> ContainProducts { get; set; } = new List<ContainProduct>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
