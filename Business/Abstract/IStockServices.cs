using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStockServices
    {
        IDataResult<List<Stock>> GetAll(); //Tüm operasyonları getir.
        IDataResult<Stock> GetByID(int ID);//ID ile operasyon getir.
        IDataResult<Stock> GetByProductID(int productID);
        IDataResult<List<StockDetailDTO>> GetStockDetails();//Gets All Stock details

        IResult Add(Stock operation);
        IResult Update(Stock operation);
    }
}
