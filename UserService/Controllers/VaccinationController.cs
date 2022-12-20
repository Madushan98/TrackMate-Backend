using AutoMapper;
using DAOLibrary.Pass;
using DAOLibrary.VaccinationData;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.VaccinationDataDto;
using Microsoft.AspNetCore.Mvc;
using UserService.ApiRoutes.V1;
using UserService.Services;

namespace UserService.Controllers;

public class VaccinationController : Controller
{
    
    private readonly IMapper _mapper;
    private readonly IVaccinationService _service;

    public VaccinationController(IVaccinationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    
    [HttpGet(UserApiRoutes.User.GetVaccinationDetails)]
    public async Task<List<VaccinationDataResponse>> GetUserPasses(Guid userId)
    {
        var result = await _service.GetUserVaccinationDetailList(userId);
        
        return result;
    }
    
    [HttpPut(UserApiRoutes.User.UpdateVaccinationDetails)]
    [ProducesResponseType(typeof(VaccinationDataResponse), 200)]
    public async Task<IActionResult> Create([FromBody]VaccinationDataCreateRequest createVaccinationRequest)
    {
        var responseDao = await _service.CreateUserVaccinationDetails(createVaccinationRequest); 
        var response = _mapper.Map<VaccinationDataResponse>(responseDao);
        return Accepted(response);
    }
   
}