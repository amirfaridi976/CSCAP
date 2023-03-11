namespace CSCAP.Models
{
    public class Bank
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
