using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;

using CustomerRelationManager.Data;

namespace CustomerRelationManager.Handlers
{
    // Auth handler class for the authentication.
    public class CrmAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ICrmRepo _repository;

        // standard class constructor.
        public CrmAuthHandler(
           ICrmRepo repository,
           IOptionsMonitor<AuthenticationSchemeOptions> options,
           ILoggerFactory logger,
           UrlEncoder encoder,
           ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _repository = repository;
        }

        // method for handling the authentication request.
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // if the request header from the client side does not include the authorisation header, then
            // fail the authentication.
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                Response.Headers.Add("WWW-Authenticate", "Basic");
                return AuthenticateResult.Fail("Authorization header not found.");
            }
            // if authorisation header is received from the client side.
            else
            {
                // get the value of the authorisation header
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                // decode the header value with base 64 encoding
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                // separate the username:password value pair into a array
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                // get the username and the password from the authorisation header value parsed earlier.
                var username = credentials[0];
                var passwordSha256Hash = getSha256Hash(credentials[1]);


                // check with the database that it's a valid admin login, and if yes:

                if (_repository.ValidLoginAdmin(username, passwordSha256Hash))
                {
                    // make a new claim of admin type and with the username.
                    var claims = new[] { new Claim("admin", username) };
                    // encapsulate the claims with identity.
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    // encapsulate the identity with principle.
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    // issue a new ticket and return the successful authentication ticket.
                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                // if the login is not an admin, check if it's a user login.
                // if it's a valid user login, issue a user ticket
                else if (_repository.ValidLoginUser(username, passwordSha256Hash))
                {
                    var claims = new[] { new Claim("user", username) };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                // if it's not a valid login, then fail the authentication request.
                else
                {
                    Response.Headers.Add("WWW-Authenticate", "Basic");
                    return AuthenticateResult.Fail("user not found or username and password do not match");
                }
            }
        }

        // static helper method to turn string into sha256 hash string.
        public static String getSha256Hash(String value)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }
    }
}
