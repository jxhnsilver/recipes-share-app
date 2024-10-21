using RecipesShare.BLL.Abstractions.Security;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Auth;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        private readonly IUserRepository _userRepository;        
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public AuthService(
            IJwtProvider jwtProvider,
            IPasswordHasher passwordHasher, 
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository
            )
        {
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;            
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }
        public async Task<Result> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userRegisterDTO.Email);

            if (existingUser is not null)
            {
                return new Result { IsSuccess = false, Message = "User already exist." };
            }

            var hashedPassword = _passwordHasher.GeneratePassword(userRegisterDTO.Password);
            var user = new User
            {
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                Email = userRegisterDTO.Email,
                PasswordHash = hashedPassword,
            };

            var addUserResult = await _userRepository.AddUserAsync(user);
            if (addUserResult == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to add the user." };
            }

            var defaultRole = await _roleRepository.GetRoleByNameAsync(StaticUserRoles.USER);
            if (defaultRole is null)
            {
                return new Result { IsSuccess = false, Message = "Failed to retrieve the role 'USER' or the role was not found" };
            }


            var addToRoleResult = await _userRoleRepository.AddToRoleAsync(CreateUserRole(user, defaultRole));
            if (addToRoleResult == 0)
            {
                return new Result { IsSuccess = false, Message = "Failed to assign the role 'USER' to the user." };
            }

            return new Result { IsSuccess = true, Message = "Registration successful." };
        }
        public async Task<Result<string>> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userLoginDTO.Email);

            if (existingUser is null)
            {
                return new Result<string> { IsSuccess = false, Message = "Invalid credentials." };
            }

            bool checkPassword = _passwordHasher.VerifyPassword(userLoginDTO.Password, existingUser.PasswordHash);

            if (!checkPassword)
            {
                return new Result<string> { IsSuccess = false, Message = "Invalid credentials." };
            }

            var token = _jwtProvider.GenerateToken(existingUser);

            return new Result<string> { IsSuccess = true, Message = "Login successful.", Value = token};
        }

        private UserRole CreateUserRole(User user, Role role)
        {
            return new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id,
            };
        } 
    }
}
