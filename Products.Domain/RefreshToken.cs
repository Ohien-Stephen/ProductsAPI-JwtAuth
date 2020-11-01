using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain
{
    public class RefreshToken
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
