using System;
using System.Collections.Generic;

namespace bakeryShop.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Roleid { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
