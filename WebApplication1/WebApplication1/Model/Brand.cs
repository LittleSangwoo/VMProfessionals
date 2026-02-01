using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Brand
{
    public int IdBrand { get; set; }

    public int IdCompany { get; set; }

    public string Brand1 { get; set; } = null!;

    public virtual Company IdCompanyNavigation { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
