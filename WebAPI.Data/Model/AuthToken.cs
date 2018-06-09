using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Model
{
    public class AuthToken
    {   public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }       
    }
}
