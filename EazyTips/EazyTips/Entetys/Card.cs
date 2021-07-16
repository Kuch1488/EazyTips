using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EazyTips.Entetys
{
    [Serializable]
    public class Card
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        [JsonProperty("valid")]
        public DateTime Valid { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("cvv")]
        public int CVV { get; set; }
        [JsonProperty("virtual")]
        public int Virtual { get; set; }
    }
}
