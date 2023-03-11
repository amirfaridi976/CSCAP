using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace CSCAP.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? ParentUserId { get; set; }
        public User? ParentUser { get; set; }
        public List<User>? ChildrenUser { get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set;}
        public int AgreedFee { get; set; }
        public int Wallet { get; set; }
        public bool IsActive { get; set; }
        public List<Payment>? Payments { get; set; }
        public int? ServerId { get; set; }
        public Server? Server { get; set; }
    }
}
