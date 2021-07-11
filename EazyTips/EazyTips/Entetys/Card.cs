using System;
using System.Collections.Generic;
using System.Text;

namespace EazyTips.Entetys
{
    [Serializable]
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public string Valid { get; set; }
        public int UserId { get; set; }
        public int CVV { get; set; }
        public int Virtual { get; set; }
    }
}
