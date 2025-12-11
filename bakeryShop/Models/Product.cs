using System;
using System.Collections.Generic;
using ReactiveUI;

namespace bakeryShop.Models;

public partial class Product : ReactiveObject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
