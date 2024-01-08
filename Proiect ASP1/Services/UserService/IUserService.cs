using Proiect_ASP1.Models;
using Proiect_ASP1.Models.DTOs;

namespace Proiect_ASP1.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task Create(User newUser);
        Task<List<User>> GetAllUsers();

    }
}
