using Proiect_ASP1.Models;

namespace Proiect_ASP1.Helper.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
