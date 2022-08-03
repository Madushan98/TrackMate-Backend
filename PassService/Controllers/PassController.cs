using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.Services;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using Microsoft.AspNetCore.Mvc;
using PassService.ApiRoutes.V1;
using PassService.Services;

namespace PassService.Controllers;

[ApiController]
public class PassController: Controller
{
    private readonly IMapper _mapper;
    private readonly IPassServices _service;
    private readonly ICryptoService _cryptoService;

    public PassController(IPassServices service, IMapper mapper, ICryptoService cryptoService)
    {
        _service = service;
        _mapper = mapper;
        _cryptoService = cryptoService;

        var asd = _cryptoService.Encrypt("preminda");
        Console.WriteLine(asd);
    }

    [HttpGet(PassApiRoutes.Pass.GetAll)]
    public async Task<IActionResult> Get([FromQuery] PaginationRequest paginationRequest)
    {
        var paginationFilter = _mapper.Map<PaginationFilter>(paginationRequest);
        var response = await _service.GetAllPass(paginationFilter);
        if (response == null) return BadRequest();

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.Create)]
    public async Task<IActionResult> Create(CreatePassRequest createPassRequest)
    {
        var result = _mapper.Map<PassDao>(createPassRequest); 
        var response = await _service.CreatePass(result);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.GetToken)]
    public async Task<IActionResult> GetToken(string createPassRequest)
    {
        var response =  _service.CreatePassToke(createPassRequest);

        return Accepted(response);
    }
    
    [HttpPost(PassApiRoutes.Pass.VerifyToken)]
    public async Task<IActionResult> ScanToken(string createPassRequest)
    {
        var pass =  _service.GetScanData(createPassRequest);
        var response = _mapper.Map<PassResponse>(pass.Result);
        return Accepted(response);
    }
}