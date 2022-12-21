using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;

namespace BaseService.Services;

using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService
{
    
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    
    
    public TokenService()
    {
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
        _symmetricSecurityKey = new SymmetricSecurityKey(key);
    }
    
    public LoginResponse GenerateAuthenticationResult(string userId, IEnumerable<Claim> claims, string refreshToken,
        UserResponse userResponse)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
    
        return new LoginResponse()
        {
            NationalId = userResponse.NationalId,
            Token = _jwtSecurityTokenHandler.WriteToken(token),
            RefreshToken = refreshToken,
            Id = userId,
            UserType = userResponse.UserType,
            User = userResponse
        };
    }
    
    public OrganizationLoginResponse GenerateOrganizationAuthenticationResult(string userId, IEnumerable<Claim> claims, string refreshToken,
        OrganizationResponse organizationResponse)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

        var org = new OrganizationLoginResponse();
        org.EmailAddress = organizationResponse.EmailAddress;
        org.Token = _jwtSecurityTokenHandler.WriteToken(token);
        org.RefreshToken = refreshToken;
        org.Id = userId;
        org.UserType = organizationResponse.UserType;
        org.OrganizationResponse = organizationResponse;

        return org;
    }

    public string GenerateEmailVerificationToken(string userId, IEnumerable<Claim> claims)
    {
        throw new NotImplementedException();
    }

    public SecurityToken ValidateRequestToken(string token)
    {
        throw new NotImplementedException();
    }
}