using Proiect_ASP.Data;
using Proiect_ASP1.Models;
using Proiect_ASP1.Repositories.GenericRepository;

namespace Proiect_ASP1.Repositories.UserRepository
{
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) 
        {

        }
        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName == username);
        }


    }
}
