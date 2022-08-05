using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DAOLIbrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.Filters;
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


    
    public async Task<PagedResponse<PassResponse>> GetAllPass(PassFilter filter,PaginationFilter pagination)
    {
        var queryable = _context.Passes.AsNoTracking();
        queryable = AddFilterOnQuery(filter, queryable);
        var pagedResponse = await PagedResponse<PassDao>.ToPagedList(queryable, pagination);
        return MappingHelper.MapPagination<PassResponse, PassDao>(pagedResponse, _mapper);
    }
    
    private IQueryable<PassDao> AddFilterOnQuery(PassFilter filter, IQueryable<PassDao> queryable)
    {
        if (Guid.Empty != filter?.UserId)
        {
            queryable = queryable.Where(pass => pass.UserId == filter.UserId);
        }
        

        return queryable;
    }

    
    public async Task<PassResponse> CreatePass(PassDao pass)
    {
        _context.Passes.Add(pass);
        await _context.SaveChangesAsync();
        return _mapper.Map<PassResponse>(pass);
    }

    public string CreatePassToke(string passId)
    {
        return _encryptService.EncryptPass(passId);
    }

    public async Task<PassDao> GetScanData(string token)
    {
        var id = _encryptService.DecryptPass(token);
        var Guid = System.Guid.Parse(id);
        var pass =await  _context.Passes
            .Include(dao=>dao.PassLogs)
            .ThenInclude(logDao=>logDao.Scanner)
            .Include(dao=>dao.ApprovedUser)
            .Include(dao=>dao.UserPassDao)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Guid);;
        return pass;
    }

}