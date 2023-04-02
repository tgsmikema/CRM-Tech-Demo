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

        public bool AddNewCustomer(CustomerInDto customerInDto, int userId)
        {

            DateTime now = DateTime.Now;

            Customer customer = new Customer
            {
                FirstName = customerInDto.FirstName,
                LastName = customerInDto.LastName,
                EmailAddress = customerInDto.EmailAddress,
                Description = customerInDto.Description,
                PhoneNumber = customerInDto.PhoneNumber,
                CreatedDateAndTime = now,
                CreatedByUserId = userId
            };

            // adding a new UserLogin type data into the database
            EntityEntry<Customer> e = _dbContext.Customers.Add(customer);
            // persist the change
            _dbContext.SaveChanges();

            return true;

        }

        public bool AddNewUser(UserRegisterInDto userRegisterInDto)
        {
            return addNewUserOrAdmin(userRegisterInDto, "user");
        }

        public bool DeleteCustomer(int customerId)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(e => e.Id == customerId);

            if (customer == null)
            {
                return false;
            }

            // delete a matching record from the database
            _dbContext.Customers.Remove(customer);

            // persist the change
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Customer> GetCustomerOutDtoList(int userId, string userType)
        {
            IEnumerable<Customer> customers;

            if (userType == "admin")
            {
                customers = _dbContext.Customers.OrderBy(e => e.Id);
            } else
            {
                customers = _dbContext.Customers.Where(e => e.CreatedByUserId == userId);
            }
            return customers;
        }

        public UserLoginOutDto GetUserLoginOutDto(string username)
        {
            // find the first occurrance of the user/admin from the database and save it into a variable. With LINQ syntax.
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
            // find the first occurrance of the user/admin from the database and save it into a variable. With LINQ syntax.
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
            // find the first occurrance of the user/admin from the database and save it into a variable. With LINQ syntax.
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
            // find the first occurrance of the user/admin from the database and save it into a variable. With LINQ syntax.
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

                // adding a new UserLogin type data into the database
                EntityEntry<UserLogin> e = _dbContext.UserLogins.Add(newUser);
                // persist the data change
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
