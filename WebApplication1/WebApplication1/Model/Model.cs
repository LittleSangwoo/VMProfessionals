using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Model
{
    public int IdModel { get; set; }

    public int IdBrand { get; set; }

    public string Model1 { get; set; } = null!;

    public virtual Brand IdBrandNavigation { get; set; } = null!;
}
