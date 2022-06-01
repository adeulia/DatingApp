using API.Entities;

namespace API.Interfaces
{
    // interface is kinda like a contract between itself and any class that implements it
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
