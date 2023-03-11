namespace CSCAP.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public Int64 Number { get; set; }
        public int BankId { get; set; }
        public Bank? Bank { get; set; }
        public int CardOwnerId { get; set; }
        public CardOwner? CardOwner { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}
