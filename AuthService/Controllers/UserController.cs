using AuthService.Contract;
using AuthService.Services;
using AutoMapper;
using DTOLibrary.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _service;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }


    [HttpPost(ApiRoutes.User.Create)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    public async Task<IActionResult> CreateAsync([FromBody] UserRequest userRequest)
    {
        var created = await _service.CreateUserAsync(userRequest);

        if (created == null) return BadRequest();

        return Accepted(created);
    }
}