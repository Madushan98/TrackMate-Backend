using AuthService.Contract;
using AuthService.Services;
using AutoMapper;
using DTOLibrary.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

public class AuthController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAuthService _service;

    public AuthController(IAuthService service, IMapper mapper) 
    {
        _service = service;
        _mapper = mapper;
    }
    
    
    [HttpPost(ApiRoutes.Auth.RegisterUser)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUserRequest createUserRequest)
    {
        var response = await _service.RegisterUserAsync(createUserRequest);

        return Accepted(response);
    }
    
}