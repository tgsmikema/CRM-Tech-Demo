using CustomerRelationManager.Model;
using CustomerRelationManager.Dtos;
using Microsoft.AspNetCore.Identity;

namespace CustomerRelationManager.Data
{
    public interface ICrmRepo
    {
        bool ValidLoginAdmin(string username, string passwordHash);
        bool ValidLoginUser(string username, string passwordHash);
        bool AddNewAdmin(UserRegisterInDto userRegisterInDto);
        bool AddNewUser(UserRegisterInDto userRegisterInDto);
    }
}
