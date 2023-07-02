﻿using System;
using System.Collections.Generic;

namespace TA.UserAccount.DataAccess.Application;

public partial class ComUserRefreshToken
{
    public string Uuid { get; set; } = null!;

    public string UserUuid { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual ComUserAccount UserUu { get; set; } = null!;
}
