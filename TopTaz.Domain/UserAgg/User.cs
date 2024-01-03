using System;
using TopTaz.Domain.FrameWorkDomain;

namespace TopTaz.Domain.UserAgg
{
    [Auditable]
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

    }
}
