namespace CSCAP.Models
{
    public class Server
    {
        public int ServerId { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public List<User>? Users { get; set; }
    }
}
