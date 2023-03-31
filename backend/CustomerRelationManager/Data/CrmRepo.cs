using CustomerRelationManager.Dtos;
using CustomerRelationManager.Model;
using CustomerRelationManager.Handlers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomerRelationManager.Data
{
    public class CrmRepo : ICrmRepo
    {
        private readonly CrmDBContext _dbContext;
        public CrmRepo(CrmDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddNewAdmin(UserRegisterInDto userRegisterInDto)
        {
            return addNewUserOrAdmin(userRegisterInDto, "admin");
        }

        public bool AddNewUser(UserRegisterInDto userRegisterInDto)
        {
            return addNewUserOrAdmin(userRegisterInDto, "user");
        }

        public UserLoginOutDto GetUserLoginOutDto(string username)
        {
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault
              (e => e.UserName == username);

            if (userLogin == null)
            {
                return null;
            }
            else
            {
                return new UserLoginOutDto
                {
                    Id = userLogin.Id,
                    UserName = userLogin.UserName,
                    UserType = userLogin.UserType,
                    FirstName = userLogin.FirstName,
                    LastName = userLogin.LastName
                };
            }
        }

        public bool ValidLoginAdmin(string username, string passwordHash)
        {
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault
              (e => e.UserName == username && e.PasswordHash == passwordHash && e.UserType == "admin");

            if (userLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidLoginUser(string username, string passwordHash)
        {
            UserLogin userLogin = _dbContext.UserLogins.FirstOrDefault
               (e => e.UserName == username && e.PasswordHash == passwordHash && e.UserType == "user");

            if (userLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool addNewUserOrAdmin(UserRegisterInDto userRegisterInDto, string userType)
        {
            UserLogin userCheck = _dbContext.UserLogins.FirstOrDefault(e => e.UserName == userRegisterInDto.UserName);

            if (userCheck == null)
            {
                UserLogin newUser = new UserLogin
                {
                    UserName = userRegisterInDto.UserName,
                    PasswordHash = CrmAuthHandler.getSha256Hash(userRegisterInDto.Password),
                    UserType = userType,
                    FirstName = userRegisterInDto.FirstName,
                    LastName = userRegisterInDto.LastName
                };

                EntityEntry<UserLogin> e = _dbContext.UserLogins.Add(newUser);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
