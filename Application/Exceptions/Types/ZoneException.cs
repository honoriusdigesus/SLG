﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class ZoneException : System.Exception
    {
        public ZoneException(string message) : base(message)
        {
        }
    }
}