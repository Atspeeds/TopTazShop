using Microsoft.AspNetCore.Identity;
using System;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.UserAgg
{
    [Auditable]
    public class User:IdentityUser
    {

        public string FullName { get; set; }

    }
}
