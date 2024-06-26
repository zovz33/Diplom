﻿using Microsoft.AspNetCore.Identity;

namespace Diplom.ASPNET.Domain.Entities.Identity;

public class UserClaim : IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}