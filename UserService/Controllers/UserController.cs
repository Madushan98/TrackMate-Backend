using AutoMapper;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.OrganizationDto;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto.AddOrganization;
using DTOLibrary.VaccinationDataDto;
using Microsoft.AspNetCore.Mvc;
using UserService.ApiRoutes.V1;
using UserService.Services;

namespace UserService.Controllers;

public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _service;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut(UserApiRoutes.User.UpdateUserOrganization)]
    [ProducesResponseType(typeof(VaccinationDataResponse), 200)]
    public async Task<IActionResult> Create([FromBody] UpdateUserOrganizationRequest updateUserOrganizationRequest)
    {
        var response = await _service.UpdateUserOrganization(updateUserOrganizationRequest);
        ;

        return Accepted(response);
    }
    
    [HttpGet(UserApiRoutes.User.GetUserOrganizations)]
    [ProducesResponseType(typeof(OrganizationResponse), 200)]
    public async Task<IActionResult> GetUserOrganization(Guid userId)
    {
        var response = await _service.GetUserOrganizationAsync(userId);

        return Accepted(response);
    }
   
    
    [HttpGet(UserApiRoutes.User.GetUserDetails)]
    public async Task<IActionResult> Get(Guid userId)
    {
        var response = await _service.GetUserDetailsAsync(userId);
           if (response == null) return BadRequest();
            
        return Accepted(response);
    }
}