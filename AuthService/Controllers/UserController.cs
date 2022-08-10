using AuthService.Contract;
using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AuthService.Services;
using AutoMapper;
using DTOLibrary.Common;
using DTOLibrary.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _service;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost(ApiRoutes.User.Update)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    public async Task<IActionResult> UpdateUser(string nationalId, [FromBody] UserUpdateRequest userUpdateRequest) 
    {
        var response = await _service.UpdateUserAsync(nationalId,userUpdateRequest);
        if (response == null) return BadRequest();

        return Ok(response);
    }

    [HttpGet(ApiRoutes.User.Get)]
    public async Task<IActionResult> GetUserDetails(string nationalId)
    {
      
        var resonse = await _service.GetUserDetailsAsync(nationalId);
        if (resonse == null) return BadRequest();

        return Ok(resonse);
    }
}