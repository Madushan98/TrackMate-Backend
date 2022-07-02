using System;

namespace AuthService.Models.Request.Queries
{
    public class GetAllUserQuery
    {
        public Guid UserId { get; set; }
        public string NationalId { get; set; }
    }
}