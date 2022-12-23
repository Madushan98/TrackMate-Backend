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
   
        var response = await _service.SavePassLog(createPassLogRequest);

        return Accepted(response);
    }

    [HttpGet(PassApiRoutes.PassLog.GetByPassId)]
    public ActionResult<List<PassLogResponse>> GetLogByPassId(Guid id)
    {
        var result = _service.GetPassLogByPassId(id).Result;
        if (result == null)
        {
            return NoContent();
        }
        var response = _mapper.Map<List<PassLogResponse>>(result);
        return response;
    }
    
    [HttpGet(PassApiRoutes.PassLog.GetByUserId)]
    public ActionResult<List<PassLogResponse>>  GetLogByUserId(Guid id)
    {
        var result = _service.GetPassLogByUserId(id).Result;
        if (result == null)
        {
            return NoContent();
        }
        var response = _mapper.Map<List<PassLogResponse>>(result);
        return response;
    } 
    
    [HttpGet(PassApiRoutes.PassLog.GetByUserIdAndDate)]
    public ActionResult<List<PassLogResponse>>  GetLogByUserIdAndDate(Guid id,[FromQuery] DateTime dateTime) 
    {
        var result = _service.GetPassLogByUserIdAndDate(id,dateTime).Result;
        
        if (result == null)
        {
            return NoContent();
        }
        var response = _mapper.Map<List<PassLogResponse>>(result);
        return response;
    }
    
    
    
    [HttpGet(PassApiRoutes.PassLog.GetByScannerId)]
    public ActionResult<List<PassLogResponse>> GetLogByScannerId(Guid id)
    {
        var result = _service.GetPassLogByScannerId(id).Result;
        if (result == null)
        {
            return NoContent();
        }
        var response = _mapper.Map<List<PassLogResponse>>(result);
        return response;
    }

}