using System.Security.Claims;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;
using Microsoft.IdentityModel.Tokens;

namespace BaseService.Services;

public interface ITokenService
{
    LoginResponse GenerateAuthenticationResult(string userId, IEnumerable<Claim> claims,
        string refreshToken, 
        UserResponse userResponse);

    string GenerateEmailVerificationToken(string userId, IEnumerable<Claim> claims);
        
        
    SecurityToken ValidateRequestToken(string token);
    
}