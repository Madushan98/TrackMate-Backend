using AutoMapper;
using BaseService.Services;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassLogDto;
using Microsoft.AspNetCore.Mvc;
using PassService.ApiRoutes.V1;
using PassService.Services;

namespace PassService.Controllers;

[ApiController]
public class PassLogController: Controller
{
    private readonly IMapper _mapper;
    private readonly IPassLogService _service;

    public PassLogController(IPassLogService service, IMapper mapper, ICryptoService cryptoService)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpPost(PassApiRoutes.PassLog.Create)]
    public async Task<IActionResult> Create(CreatePassLogRequest createPassLogRequest)
    {
        var result = _mapper.Map<PassLogDao>(createPassLogRequest); 
        var response = await _service.SavePassLog(result);

        return Accepted(response);
    }

    [HttpGet(PassApiRoutes.PassLog.Get)]
    public List<PassLogResponse> GetLogById(Guid id)
    {
        var result = _service.GetPassLogByPassId(id).Result;
        var response = _mapper.Map<List<PassLogResponse>>(result);
        return response;
    }

}