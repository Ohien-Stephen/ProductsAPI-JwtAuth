﻿namespace Products.Models
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserModel User { get; set; }
    }
}
