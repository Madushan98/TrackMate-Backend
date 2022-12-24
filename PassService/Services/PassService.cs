using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.PassToken;
using DTOLibrary.UserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassService.ApiRoutes.V1;

namespace PassService.Services;

public class PassService : IPassServices
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
            .FirstOrDefaultAsync(pass => pass.Id == id);

        _context.Passes.Remove(pass);

        var saveChangesAsync = await _context.SaveChangesAsync();
        return saveChangesAsync > 0;
    }

    public async Task<PassDao> CreatePass(PassDao pass)
    {
        pass.GeneratedDateTime = DateTime.Now;
        _context.Passes.Add(pass);
        await _context.SaveChangesAsync();
        return pass;
    }

    public async Task<PassTokenResponse> CreatePassToke(Guid passId)
    {
        var passTokenResponse = new PassTokenResponse()
        {
            PassToken = _encryptService.EncryptPass(passId.ToString()),
        };
        return passTokenResponse;
    }

    public async Task<PassResponse> GetScanData(string token)
    {
        var id = _encryptService.DecryptPass(token);
        var guid = System.Guid.Parse(id);
        Console.WriteLine(guid);
        var pass = await _context.Passes
            .Include(dao => dao.PassLogs)
            .ThenInclude(logDao => logDao.Scanner)
            .Include(dao => dao.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(pass => pass.Id == guid);
        var response = _mapper.Map<PassResponse>(pass);
        response.FullName = pass.User.FullName;
        response.PrimaryContactNumber = pass.User.PrimaryContactNumber;

        return response;
    }

    public async Task<UserDao?> GetUserByNationalIdAsync(string nationalId)
    {
        var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (firstOrDefaultAsync == null)
        {
        }

        return firstOrDefaultAsync;
    }

    public async Task<List<PassDao>> GetPassByUserId(Guid userId)
    {
        var passList = _context.Passes.Where(dao => dao.UserId == userId).ToList();
        List<PassDao> expPasses = new List<PassDao>();

        foreach (var passDao in passList)
        {
            if (passDao.EndDateTime < DateTime.Now)
            {
                expPasses.Add(passDao);
            }
        }

        if (expPasses.Count >= 1)
        {
            _context.Passes.RemoveRange(expPasses.AsQueryable());
            var save = await _context.SaveChangesAsync();
            if (save > 0)
            {
                passList = _context.Passes.Where(dao => dao.UserId == userId).ToList();
            }
        }

        return passList;
    }

    public async Task<PassResponse> UpdatePassById(Guid id, PassUpdateRequest request)
    {
        var exisit = await _context.Passes.AsNoTracking().FirstOrDefaultAsync(pass => pass.Id == id);
        if (exisit == null)
        {
            return null;
        }

        var dao = _mapper.Map<PassDao>(request);
        _context.Passes.Update(dao);
        var saveAsyncChange = await _context.SaveChangesAsync();
        if (saveAsyncChange > 0)
        {
            var organizationById = await _context.Passes.AsNoTracking().FirstOrDefaultAsync(pass => pass.Id == id);
            return _mapper.Map<PassResponse>(organizationById);
        }

        return null;
    }
}