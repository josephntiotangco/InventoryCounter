using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryCounter.Classes
{
    public class Constructors
    {
        public class TokenRequest
        {
            public string login_type { get; set; }
            public string grant_type { get; set; }
            public string password { get; set; }
            public string email { get; set; }
        }
        public class TokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
            public int created_at { get; set; }
        }
    }
}
