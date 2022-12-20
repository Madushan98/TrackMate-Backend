using System.Linq;
using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.VaccinationData;
using DAOLibrary.VacinationData;
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
        var user = await _context.Users.AsNoTracking().Where(user => user.Id == userId)
            .FirstOrDefaultAsync();

        List<VaccinationDataDao> vaccinationDataResponses = new List<VaccinationDataDao>();


        if (user.VaccinationUserDao == null)
        {
            return new List<VaccinationDataResponse>();
        }
        
        foreach (var vaccinationUserDao in user.VaccinationUserDao)
        {
            VaccinationDataDao vaccinationDataDao = vaccinationUserDao.VaccinationData;
            vaccinationDataResponses.Add(vaccinationDataDao);
        }

        var response = _mapper.Map<List<VaccinationDataResponse>>(vaccinationDataResponses);

        return response;
    }

    public async Task<VaccinationDataResponse>  CreateUserVaccinationDetails(
        VaccinationDataCreateRequest vaccinationDataCreateRequest)
    {
        var user = await _context.Users.AsNoTracking().Where(user => user.Id == vaccinationDataCreateRequest.UserId)
            .FirstOrDefaultAsync();

        if (user.VaccinationUserDao == null)
        {
            user.VaccinationUserDao = new List<VaccinationUserDao>();
        }
        
        var newVaccinationData = _mapper.Map<VaccinationDataDao>(vaccinationDataCreateRequest); 
        
        var result = _context.VaccinationDatas.Add(newVaccinationData);
        
        user.VaccinationUserDao.Add(new VaccinationUserDao()
        {
            VaccinationData = result.Entity,
            User = user
        });
        
        await _context.SaveChangesAsync();
        
        var response = _mapper.Map<VaccinationDataResponse>(result.Entity);
        
        return response;
        
    }
}