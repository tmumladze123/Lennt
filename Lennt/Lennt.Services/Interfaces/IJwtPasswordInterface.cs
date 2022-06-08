namespace Lennt.Services.Interfaces
{
    public interface IJwtPasswordInterface
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string hashed);
        string GenerateJwtToken(string username, long UserId);
        int GetUserId();
        string GetRole();
    }
}
