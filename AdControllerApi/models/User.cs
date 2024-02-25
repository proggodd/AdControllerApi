namespace MyAdsApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Coins { get; set; }
        // Additional properties such as FirstName, LastName, etc., can be added as needed
    }
}
