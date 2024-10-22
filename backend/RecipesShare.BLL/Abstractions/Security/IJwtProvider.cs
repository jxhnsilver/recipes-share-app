using RecipesShare.DAL.Entities;

namespace RecipesShare.BLL.Abstractions.Security
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
