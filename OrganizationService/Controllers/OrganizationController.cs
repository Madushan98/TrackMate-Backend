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
    
    [HttpGet(OrganizationApiRoutes.Organization.Get)]
    public async Task<ActionResult<OrganizationResponse>> Get(Guid id)
    {
        var organization = await _service.GetOrganizationById(id);
        if (organization == null) return NotFound();
        var response = _mapper.Map<OrganizationResponse>(organization);

        return Accepted(response);
    }
    
    [HttpPost(OrganizationApiRoutes.Organization.Create)]
    [ProducesResponseType(typeof(OrganizationResponse), 200)]
    public async Task<IActionResult> Create(CreateOrganizationRequest createOrganizationRequest)
    {
        var result = _mapper.Map<OrganizationDao>(createOrganizationRequest); 
        var responseDao = await _service.CreateOrganization(result);
        var response = _mapper.Map<OrganizationResponse>(responseDao);

        return Accepted(response);
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