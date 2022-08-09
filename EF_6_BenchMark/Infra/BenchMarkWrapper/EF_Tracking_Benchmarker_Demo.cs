using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using EF_6_BenchMark.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using System.Threading;

using BenchmarkDotNet.Reports;
using EF_6_BenchMark.Model;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace EF_6_BenchMark.Infra.BenchMarkWrapper
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [ShortRunJob, Config(typeof(Config))]
    public class EF_Tracking_Benchmarker_Demo
    {

        private class Config : ManualConfig
        {
            public Config()
            {
                SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
            }
        }


        [Benchmark(Baseline = true)]
        public double LoadEntity()
        {
            var sum = 0;
            var count = 0;
            var ctx = new BenchMarkingDBContext();
            foreach (var data in ctx.BenchMarkTable)
            {
                sum += data.ID;
                count++;
            }

            return (double)sum / count;
        }


        //[Benchmark(Baseline = true)]
        //public double LoadEntityWithNoTracking()
        //{
        //    var sum = 0;
        //    var count = 0;
        //    var ctx = new BenchMarkingDBContext();
        //    foreach (var data in ctx.BenchMarkTable.AsNoTracking())
        //    {
        //        sum += data.ID;
        //        count++;
        //    }

        //    return (double)sum / count;
        //}



        [Benchmark]
        public double LoadEntityWithDapper()
        {
            string CnString = @"Server=ALIKOLAHDOOZAN;Database=BenchMarkDB;Trusted_Connection=True;";            
            //
            var sum = 0;
            var count = 0;
            string sqlCommand = "SELECT * FROM BenchMarkTablewith5000Records";
            var con = new SqlConnection(CnString);
            var result = con.Query<BenchMarkTablewith5000Records>(sqlCommand).ToList();
            foreach (var data in result)
            {
                sum += data.ID;
                count++;
            }
            return (double)sum / count;
        }

    }
}
