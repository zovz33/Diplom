﻿using Microsoft.AspNetCore.Identity;

namespace Diplom.ASPNET.Domain.Entities.Identity;

public class RoleClaim : IdentityRoleClaim<int>
{
    public virtual Role Role { get; set; }
}