using System;
using System.Collections.Generic;

namespace TA.UserAccount.DataAccess.Application;

public partial class ComUserInRole
{
    public string Uuid { get; set; } = null!;

    public string UserUuid { get; set; } = null!;

    public string RoleUuid { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual ComRole RoleUu { get; set; } = null!;

    public virtual ComUserAccount UserUu { get; set; } = null!;
}
