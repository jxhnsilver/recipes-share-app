namespace RecipesShare.BLL.Abstractions.Security
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
