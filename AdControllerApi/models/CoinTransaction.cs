using System;

namespace MyAdsApi.Models
{
    public class CoinTransaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionType { get; set; }
        // Additional properties or methods as needed
    }
}
