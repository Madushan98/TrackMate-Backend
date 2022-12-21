using System.Security.Claims;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;
using Microsoft.IdentityModel.Tokens;

namespace BaseService.Services;

public interface ITokenService
{
    LoginResponse GenerateAuthenticationResult(string userId, IEnumerable<Claim> claims,
        string refreshToken, 
        UserResponse userResponse);
    
    OrganizationLoginResponse GenerateOrganizationAuthenticationResult(string userId, IEnumerable<Claim> claims,
        string refreshToken, OrganizationResponse userResponse);
    string GenerateEmailVerificationToken(string userId, IEnumerable<Claim> claims);
        
        
    SecurityToken ValidateRequestToken(string token);
    
}

