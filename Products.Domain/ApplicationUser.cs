using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
