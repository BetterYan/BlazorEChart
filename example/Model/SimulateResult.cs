using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWeb.Shared
{
    public record SimulateResult
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double StartAssert { get; set; }
        public double FinalAssert { get; set; }
        public double FinalEarningRatio => FinalAssert / StartAssert - 1;
        public double StockMaxEarningRatio { get; set; }
        public double StockMinEarningRatio { get; set; }
        public double AssertMaxEarningRatio { get; set; }
        public double AssertMinEarningRatio { get; set; }
        public List<Trade> Trades { get; set; }
    }
}
