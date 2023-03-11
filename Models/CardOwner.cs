namespace CSCAP.Models
{
    public class CardOwner
    {
        public int CardOwnerId { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
