using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
