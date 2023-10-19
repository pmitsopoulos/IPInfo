﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Exceptions.ExternalServices
{
    public class IPServiceNotAvailableException : Exception
    {
        public IPServiceNotAvailableException()
        {

        }
        public IPServiceNotAvailableException(string message)
            : base(message)
        {

        }

        public IPServiceNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
