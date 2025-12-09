using System;
using System.Collections.Generic;

namespace bakeryShop.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int Productid { get; set; }

    public int Employeeid { get; set; }

    public int Quantity { get; set; }

    public int Totalprice { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
