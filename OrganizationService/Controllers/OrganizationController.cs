using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLibrary.Organization;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.OrganizationDto;
using Microsoft.AspNetCore.Mvc;
using OrganizationService.ApiRoutes.V1;
using OrganizationService.Services;

namespace OrganizationService.Controllers;

public class OrganizationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IOrganizationService _service;
    
    public OrganizationController(IOrganizationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet(OrganizationApiRoutes.Organization.GetAll)]
    public async Task<IActionResult> Get([FromQuery] PaginationRequest paginationRequest)
    {
        var paginationFilter = _mapper.Map<PaginationFilter>(paginationRequest);
        var pagedResponse = await _service.GetAllOrganization(paginationFilter);
        var response = MappingHelper.MapPagination<OrganizationResponse, OrganizationDao>(pagedResponse, _mapper);
        if (response == null) return BadRequest();
            
        return Accepted(response);
    }
    
    [HttpGet(OrganizationApiRoutes.Organization.GetAllUser)]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllUserQuery query,
        [FromQuery] PaginationRequest paginationRequest)
    {
        var paginationFilter = _mapper.Map<PaginationFilter>(paginationRequest);
        var filter = _mapper.Map<UserFilter>(query);
        var resonse = await _service.GetAllUsersAsync(filter, paginationFilter);
        if (resonse == null) return BadRequest();

        return Accepted(resonse);
    }
    
    [HttpGet(OrganizationApiRoutes.Organization.Get)]
    public async Task<ActionResult<OrganizationResponse>> Get(Guid id)
    {
        var organization = await _service.GetOrganizationById(id);
        if (organization == null) return NotFound();
        var response = _mapper.Map<OrganizationResponse>(organization);

        return Accepted(response);
    }
    
    [HttpGet(OrganizationApiRoutes.Organization.GetUserById)]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        
        var resonse = await _service.GetUserByIdAsync(id);
        if (resonse == null) return BadRequest();

        return Accepted(resonse);
    }
    
    [HttpPut(OrganizationApiRoutes.Organization.Update)]
    public async Task<ActionResult<OrganizationResponse>> Update(Guid id,[FromBody] UpdateOrganizationRequest request)
    {
        var update =await _service.UpdateOrganization(id, request);
        if (update != null)
        {
            return Ok(update);
        }

        return BadRequest();
    }
    


    [HttpDelete(OrganizationApiRoutes.Organization.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool exists = await _service.GetOrganizationById(id) !=null;
        if (!exists)
        {
            return NotFound();
        }

        bool updated = await _service.DeleteById(id);
        if (updated)
        {
            return Ok();
        }

        return BadRequest();
    }

}