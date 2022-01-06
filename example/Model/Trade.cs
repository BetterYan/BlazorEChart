using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWeb.Shared
{
    public record Trade
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double TotalPrice => Amount * Price;
        public Direction OrderDirection { get; set; }

        public enum Direction
        {
            Buy,
            Sell
        }
    }
}
