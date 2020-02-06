using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authentication
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
