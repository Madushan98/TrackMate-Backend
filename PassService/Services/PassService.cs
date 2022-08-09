using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DAOLIbrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassService.ApiRoutes.V1;

namespace PassService.Services;

public class PassService: IPassServices
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly IPassEncryptService _encryptService;

    public PassService(DBContext context, IMapper mapper, IPassEncryptService encryptService)
    {
        _context = context;
        _mapper = mapper;
        _encryptService = encryptService;
    }

    
    public async Task<PagedResponse<PassDao>> GetAllPass(PaginationFilter pagination)
    {
        var queryable = _context.Passes.AsNoTracking();
        var pagedResponse = await PagedResponse<PassDao>.ToPagedList(queryable, pagination);
        return pagedResponse;
    }

    public async Task<PassDao?> GetPassById(Guid id)
    {
        var pass = await _context.Passes.FirstOrDefaultAsync(pass => pass.Id == id);
        return pass;
    }

    public async Task<bool> DeleteById(Guid id)
    {
        var pass = await _context.Passes
            .FirstOrDefaultAsync(pass=>pass.Id == id);

        _context.Passes.Remove(pass);
        
        var saveChangesAsync = await _context.SaveChangesAsync();
        return saveChangesAsync > 0;
    }
    
    public async Task<PassDao> CreatePass(PassDao pass)
    {
        _context.Passes.Add(pass);
        await _context.SaveChangesAsync();
        return pass;
    }

    public string CreatePassToke(Guid passId)
    {
        return _encryptService.EncryptPass(passId.ToString());
    }

    public async Task<PassDao> GetScanData(string token)
    {
        var id = _encryptService.DecryptPass(token);
        var guid = System.Guid.Parse(id);
        Console.WriteLine(guid);
        var pass =await  _context.Passes
            .Include(dao=>dao.PassLogs)
            .ThenInclude(logDao=>logDao.Scanner)
            .Include(dao=>dao.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(pass => pass.Id == guid);
        return pass;
    }

}