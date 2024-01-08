using Proiect_ASP.Models.Base;
using Proiect_ASP1.Models.Enums;
using System.Text.Json.Serialization;

namespace Proiect_ASP1.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email{ get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }

    }
}
