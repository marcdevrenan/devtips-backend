﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Requests
{
    public class LoginUserRequest
    {
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
    }
}
