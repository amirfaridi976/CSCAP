namespace CSCAP.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Price { get; set; }
        public bool IsVerified { get; set; }
    }
}
