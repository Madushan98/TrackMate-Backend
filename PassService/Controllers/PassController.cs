using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.Services;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.Filters;
using Microsoft.AspNetCore.Mvc;
using PassService.ApiRoutes.V1;
using PassService.Services;

namespace PassService.Controllers;


public class PassController: Controller
{
    private readonly IMapper _mapper;
    private readonly IPassServices _service;

    public PassController(IPassServices service, IMapper mapper, ICryptoService cryptoService)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet(PassApiRoutes.Pass.GetAll)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> Get([FromQuery] PassFilter query,[FromQuery] PaginationRequest paginationRequest)
    {
        var paginationFilter = _mapper.Map<PaginationFilter>(paginationRequest);
        var filter = _mapper.Map<PassFilter>(query);
        var response = await _service.GetAllPass(filter,paginationFilter);
        if (response == null) return BadRequest();

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.Create)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> Create(CreatePassRequest createPassRequest)
    {
        var result = _mapper.Map<PassDao>(createPassRequest); 
        var response = await _service.CreatePass(result);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.GetToken)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> GetToken(string createPassRequest)
    {
        var response =  _service.CreatePassToke(createPassRequest);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.VerifyToken)]
    [ProducesResponseType(typeof(PassResponse), 200)]
    public async Task<IActionResult> ScanToken(string createPassRequest)
    {
        var pass =  _service.GetScanData(createPassRequest);
        var response = _mapper.Map<PassResponse>(pass.Result);
        return Accepted(response);
    }
}