﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_kr_471221012.Exceptions
{
    class InvalidValueException : Exception
    {
        public InvalidValueException(string m):base(m)
        {

        }
    }
}
