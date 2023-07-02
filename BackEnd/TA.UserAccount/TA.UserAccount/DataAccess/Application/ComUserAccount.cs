using System;
using System.Collections.Generic;

namespace TA.UserAccount.DataAccess.Application;

public partial class ComUserAccount
{
    public string Uuid { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string TimeZoneId { get; set; } = null!;

    public bool IsArchived { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ComUserInRole> ComUserInRoles { get; set; } = new List<ComUserInRole>();

    public virtual ICollection<ComUserMembership> ComUserMemberships { get; set; } = new List<ComUserMembership>();
}
