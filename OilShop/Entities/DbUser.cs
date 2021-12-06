using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OilShop.Entities
{
    public class DbUser : IdentityUser<long>
    {
        public string FullName { get; set; }
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
    }
}
