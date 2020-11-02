using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool isExpired => DateTime.UtcNow >= Expires;

        //public bool isActive { get; set; }
        public DateTime Expires { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
