using System;
using System.Collections.Generic;

namespace WebApplication1.Model;

public partial class User
{
    public string IdUser { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool IsEngineer { get; set; }

    public bool IsOperator { get; set; }

    public int IdRole { get; set; }

    public virtual ICollection<Checking> Checkings { get; set; } = new List<Checking>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Maintenace> Maintenaces { get; set; } = new List<Maintenace>();
}
