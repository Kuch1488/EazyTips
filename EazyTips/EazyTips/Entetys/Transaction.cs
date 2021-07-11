using System;
using System.Collections.Generic;
using System.Text;

namespace EazyTips.Entetys
{
    [Serializable]
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int ToCard { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
    }
}
