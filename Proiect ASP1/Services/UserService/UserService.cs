using Proiect_ASP1.Helper.JwtToken;
using Proiect_ASP1.Models.DTOs;
using Proiect_ASP1.Models;
using Proiect_ASP1.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;
namespace Proiect_ASP1.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }


            // jwt generation
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

    }
}
