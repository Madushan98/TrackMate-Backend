using System;

namespace AuthService.Domain.Filters
{
    public class UserFilter
    {
        public Guid UserId { get; set; }
        public string NationalId { get; set; }
    }
}