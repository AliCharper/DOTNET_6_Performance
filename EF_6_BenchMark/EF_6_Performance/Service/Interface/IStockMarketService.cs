using EF_6_BenchMark.EF_6_Performance.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.EF_6_Performance.Service.Interface
{
    public interface IStockMarketService
    {
        Task BulkInsertAsync(int NumberOfRows, string state);
        void BulkUpdate(int NumberOfRows);
        void BulkDelete(int NumberOfRows);
        Task BulkInsertfromlist(IEnumerable<StockMarket> Data);
        List<StockMarket> LoadStockBasedOnState(string State);
        Task<IEnumerable<StockMarket>> LoadStockBasedOnStateByRawSQL(string State);
    }
}

