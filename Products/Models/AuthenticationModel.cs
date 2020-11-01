using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserModel User { get; set; }
    }
}
