using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public string Timestamp { get; set; } = null!;

    public string IdProduct { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public int Quantity { get; set; }

    public int IdPaymentMethod { get; set; }

    public string IdMachine { get; set; } = null!;

    public virtual VendingMachine IdMachineNavigation { get; set; } = null!;

    public virtual PayMethod IdPaymentMethodNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
