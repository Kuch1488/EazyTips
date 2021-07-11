using System;
using System.Collections.Generic;
using System.Text;

namespace EazyTips.Entetys
{
    [Serializable]
    public class Marketplace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
