using System;
using System.Collections.Generic;

namespace TA.UserAccount.DataAccess.Application;

public partial class ComRole
{
    public string Uuid { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ComUserInRole> ComUserInRoles { get; set; } = new List<ComUserInRole>();
}
