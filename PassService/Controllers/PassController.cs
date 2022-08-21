using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.Services;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.Filters;
using DTOLibrary.PassDto.PassToken;
using Microsoft.AspNetCore.Mvc;
using PassService.ApiRoutes.V1;
using PassService.Services;

namespace PassService.Controllers;

[ApiController]
public class PassController: Controller
{
    private readonly IMapper _mapper;
    private readonly IPassServices _service;

    public PassController(IPassServices service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet(PassApiRoutes.Pass.GetAll)]
    public async Task<IActionResult> Get([FromQuery] PaginationRequest paginationRequest)
    {
        var paginationFilter = _mapper.Map<PaginationFilter>(paginationRequest);
        var pagedResponse = await _service.GetAllPass(paginationFilter);
        var response = MappingHelper.MapPagination<PassResponse, PassDao>(pagedResponse, _mapper);
        if (response == null) return BadRequest();

        return Accepted(response);
    }
    
    [HttpGet(PassApiRoutes.Pass.Get)]
    public async Task<ActionResult<PassResponse>> Get(Guid id)
    {
        var pass = await _service.GetPassById(id);
        if (pass == null) return NotFound();
        var response = _mapper.Map<PassResponse>(pass);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.Create)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> Create(CreatePassRequest createPassRequest)
    {
        var result = _mapper.Map<PassDao>(createPassRequest); 
        var responseDao = await _service.CreatePass(result);
        var response = _mapper.Map<PassResponse>(responseDao);

        return Accepted(response);
    }

    [HttpDelete(PassApiRoutes.Pass.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool exists = await _service.GetPassById(id) !=null;
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

    [HttpGet(PassApiRoutes.Pass.GetToken)]
    [ProducesResponseType(typeof(PassTokenResponse), 200)]
    public async Task<IActionResult> GetToken(Guid createPassRequest)
    {
        var response = await _service.CreatePassToke(createPassRequest);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.VerifyToken)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> ScanToken(VerifyTokenRequest verifyTokenRequest)
    {
        var passResponse = await _service.GetScanData(verifyTokenRequest.PassToken);
        return Accepted(passResponse);
    }
}