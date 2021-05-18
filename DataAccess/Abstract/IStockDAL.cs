using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IStockDAL: IEntityRepository<Stock>
    {
        List<StockDetailDTO> GetStockDetails();//Gets All Stock details
    }
}
