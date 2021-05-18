using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //Tüm IResult dönüş tipli kuralları buraya göndereceğiz. Bu bir Business motoru
        {
            foreach (var logic in logics) //tüm kurallar için
            {
                if (!logic.Success)//eğer ki bir kural fail ise (? ya birden fazla fail varsa?)
                {
                    return logic; //o kuralı gönder.
                }
            }
            return null;
        }
    }
}
