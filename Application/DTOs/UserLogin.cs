﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserLogin
    {
        public string Document { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
