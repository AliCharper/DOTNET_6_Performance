using EF_6_BenchMark.EF_6_Performance.Entity;
using EF_6_BenchMark.EF_6_Performance.Service.Interface;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.EF_6_Performance.Service.Concrete
{
    public class StockMarketService : IStockMarketService
    {
        public async Task BulkInsertAsync(int NumberOfRows, string state)
        {
            var _StockMarketContext = new StockMarketContext();
            var stockMarkets = Enumerable.Range(0, NumberOfRows).Select(i => new StockMarket
            {
                Name = i.ToString(),
                Family = i.ToString(),
                State = state,
                StockShare = i,
                LogTime=DateTime.Now
            }).ToList();
            await _StockMarketContext.BulkInsertAsync(stockMarkets);
        }

        public async Task BulkInsertfromlist(IEnumerable<StockMarket> Data)
        {
            var _StockMarketContext = new StockMarketContext();
            await _StockMarketContext.BulkInsertAsync(Data.ToList());
        }

        public async Task<IEnumerable<StockMarket>> LoadStockBasedOnStateByRawSQL(string State)
        {
            var _StockMarketContext = new StockMarketContext();
            var data = await _StockMarketContext.StockMarket
                                           .FromSqlRaw("SELECT [ID],[StockShare],[Name],[Family],[State],[LogTime] FROM [dbo].[StockMarket] Where [State] = {0}", State)
                                           .AsNoTracking().ToArrayAsync();
            return data;
        }


        public List<StockMarket> LoadStockBasedOnState(string State)
        {
            var _StockMarketContext = new StockMarketContext();
            var data = _StockMarketContext.StockMarket
                .Where(x=>x.State==State)
                .AsNoTracking().ToList();
            return data;
        }

        public void BulkDelete(int NumberOfRows)
        {
            throw new NotImplementedException();
        }



        public void BulkUpdate(int NumberOfRows)
        {
            throw new NotImplementedException();
        }

        //public Array LoadStockBasedOnStateCompiledQuery(string State)
        //{
        //    using (var db = new StockMarketContext())
        //    {
        //        var Data = ListOfStockBasedOnStateByCompiledQuery(db, State);
        //        return Data;
        //    }
        //}


        //public List<StockMarket> LoadStockBasedOnStateByRawSQL(string State)
        //{
        //    StockMarketContext _StockMarketContext = new StockMarketContext();
        //    var data = _StockMarketContext.StockMarket.FromSqlRaw("SELECT [ID],[StockShare],[Name],[Family],[State] FROM[dbo].[StockMarket] Where [State] = {0}", State)
        //        .AsNoTracking()
        //        .ToList();
        //    return data;
        //}

        //private static Func<StockMarketContext, string, Array> ListOfStockBasedOnStateByCompiledQuery =
        //     EF.CompileQuery((StockMarketContext db, string State) => db.StockMarket
        //    .Where(x => x.State == State)
        //    .AsNoTracking().ToArray());

    }
}
