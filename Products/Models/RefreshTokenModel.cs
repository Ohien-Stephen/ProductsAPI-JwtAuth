using System;

namespace Products.Models
{
    public class RefreshTokenModel
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
