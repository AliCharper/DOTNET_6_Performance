using EF_6_BenchMark.EF_6_Performance.Entity;
using EF_6_BenchMark.EF_6_Performance.Helper;
using EF_6_BenchMark.EF_6_Performance.Service.Concrete;
using System.Diagnostics;



//Start Time
CustomLogger.SaveTime("Main Thread: Application has just been Started...");

Stopwatch stw = new Stopwatch();
IEnumerable<StockMarket> data;
StockMarketService Sr = new StockMarketService();
const int Row_Numbers = 150_000;


string[] States = {
    "Alabama",
    "Alaska",
    "Arizona",
    "Arkansas",
    "California",
    "Colorado",
    "Connecticut",
    "Delaware",
    "Florida",
    "Georgia"
};



stw.Start();
CustomLogger.SaveTime("Main Thread: StopWatch has just been Started...");



await Parallel.ForEachAsync(States, (state, tmp) =>
{
    CustomLogger.SaveTime($"Thread of State {state} : Iteration has just been Started");

    Parallel.Invoke(
            async () =>
             {
                 CustomLogger.SaveTime($"Thread of operation for State:{state} - Iteration has just been Started");

                 await Sr.BulkInsertAsync(Row_Numbers, state);
                 //
                 data = await Sr.LoadStockBasedOnStateByRawSQL(state);
                 Parallel.ForEach(data, x => x.StockShare += 10);
                 await Sr.BulkInsertfromlist(data);

                 CustomLogger.SaveTime($"Thread of operation for State:{state} - Iteration has just been Finished");
             }
           );

    CustomLogger.SaveTime($"Thread of State {state} : Iteration has just been Finished");
    return ValueTask.CompletedTask;
});

stw.Stop();
CustomLogger.SaveTime("Main Thread: StopWatch has just been FINISHED");

Thread.Sleep(10000);

CustomLogger.SaveTime("Main Thread: Application has just been FINISHED");
CustomLogger.SaveToFile();

Console.ReadKey();