using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DTOLibrary.PassLogDto;

namespace PassService.Services;

public class PassLogService: IPassLogService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;

    public PassLogService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PassLogDao> SavePassLog(PassLogDao passLogDao)
    {
        _context.PassLogs.Add(passLogDao);
        await _context.SaveChangesAsync();
        return passLogDao;
    }
}