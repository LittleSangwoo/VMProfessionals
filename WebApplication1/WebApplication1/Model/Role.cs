using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class Role
{
    public int IdRole { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
