using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassLogDto;
using Microsoft.EntityFrameworkCore;

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
        passLogDao.LogTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        _context.PassLogs.Add(passLogDao);
        await _context.SaveChangesAsync();
        return passLogDao;
    }

    public async Task<List<PassLogDao>> GetPassLogByPassId(Guid passId)
    {
        var loglist =_context.PassLogs.Where(dao=>dao.PassId == passId).ToList();
        
        return loglist;
    }
    
    public async Task<List<PassLogDao>> GetPassLogByUserId(Guid userId)
    {
        var loglist =_context.PassLogs.Where(dao=>dao.UserId == userId).ToList();
        
        return loglist;
    }
    
    public async Task<List<PassLogDao>> GetPassLogByScannerId(Guid ScannerId)
    {
        var loglist =_context.PassLogs.Where(dao=>dao.ScannerId == ScannerId).ToList();
        
        return loglist;
    }
}