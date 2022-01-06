using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWeb.Shared
{
    public record Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Price> Prices { get; set; }
        public List<ShareBonus> ShareBonus { get; set; }
    }
}
