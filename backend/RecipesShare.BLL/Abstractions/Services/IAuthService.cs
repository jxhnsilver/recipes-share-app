using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Auth;

namespace RecipesShare.BLL.Abstractions.Services
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(UserRegisterDTO userRegisterDTO);
        Task<Result<string>> LoginAsync(UserLoginDTO userLoginDTO);
    }
}
