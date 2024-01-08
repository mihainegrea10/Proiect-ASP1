using Proiect_ASP1.Models;
using Proiect_ASP1.Repositories.GenericRepository;

namespace Proiect_ASP1.Repositories.UserRepository
{
    public interface IUserRepository :IGenericRepository<User>
    {
        User FindByUsername(string username);
    }
}
