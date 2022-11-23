using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Domain.User
{
    [Table("AdminUser")]
    public class AdminUser : User
    {
        public override UserRole Role => UserRole.ADMIN_USER;
    }
}
