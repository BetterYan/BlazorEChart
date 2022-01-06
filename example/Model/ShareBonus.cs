using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWeb.Shared
{
    public record ShareBonus
    {
        public int Id { get; set; }
        public double BonusIssueCount { get; set; } //送股
        public double ShareTransferCount { get; set; } //转股
        public double Payout { get; set; } //派息
        public DateTime ExDate { get; set; } //除权除息日
        public DateTime? BonusShareDate { get; set; } //红股上市日

        public int StockId { get; set; }
    }
}
