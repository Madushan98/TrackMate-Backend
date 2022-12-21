using System.Linq;
using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.VaccinationData;
using DTOLibrary.VaccinationDataDto;
using Microsoft.EntityFrameworkCore;

namespace UserService.Services;

public class VaccinationService : IVaccinationService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;

    public VaccinationService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<List<VaccinationDataResponse>> GetUserVaccinationDetailList(Guid userId)
    {
        var user = await _context.Users.AsNoTracking().Where(user => user.Id == userId).Include(user => user.VaccinationData).FirstOrDefaultAsync();
          

        if (user.VaccinationData == null)
        {
            return new List<VaccinationDataResponse>();
        }
        
        List<VaccinationDataDao> vaccinationDataResponses = new List<VaccinationDataDao>();

        foreach (var vaccinationData in user.VaccinationData)
        {
            vaccinationDataResponses.Add(vaccinationData);
        }

        var response = _mapper.Map<List<VaccinationDataResponse>>(vaccinationDataResponses);

        return response;
    }

    public async Task<VaccinationDataResponse> CreateUserVaccinationDetails(
        VaccinationDataCreateRequest vaccinationDataCreateRequest)
    {
        var user = await _context.Users.AsNoTracking().Where(user => user.Id == vaccinationDataCreateRequest.UserId).Include(user => user.VaccinationData)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var newVaccinationData = _mapper.Map<VaccinationDataDao>(vaccinationDataCreateRequest);

        var result = _context.VaccinationDatas.Add(newVaccinationData);
        
        await _context.SaveChangesAsync();

        var response = _mapper.Map<VaccinationDataResponse>(result.Entity);

        return response;
    }
}