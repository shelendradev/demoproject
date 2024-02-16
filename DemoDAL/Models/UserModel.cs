using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDAL.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]

        public string LastName { get; set; }
        [Column("roleid")]

        public int RoleID  { get; set; }
        [Column("isverified")]

        public bool IsVerified { get; set; }
        [Column("istwofactorenabled")]

        public bool IsTwoFactorEnabled {  get; set; }
        [Column("isaccountlocked")]
        public bool IsAccountLocked { get; set; }
    }
}
