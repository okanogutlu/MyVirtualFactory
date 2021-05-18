﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message = null) : base(false, message) //Default olarak true vermiş olduk.
        {

        }
    }
}
