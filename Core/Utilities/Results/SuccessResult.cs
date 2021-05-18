using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message=null) : base(true, message) //Default olarak true vermiş olduk.
        {

        }
    }
}
