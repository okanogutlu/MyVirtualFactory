using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult //yaptığımız işlemler sonucunda, işlemin gerçekleşip gerçekleşmediği, ve mesaj için kullanılan bir interface.
    {

         bool Success { get; }
        string Message { get; }
    }
}
