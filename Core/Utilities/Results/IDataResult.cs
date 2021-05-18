using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> :IResult //Zaten mesaj ve bool içerek, bu yüzden tekrardan yazmaya gerek yok.
    {
        T Data { get; }
    }
}
