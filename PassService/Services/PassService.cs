using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Pass;
using DAOLibrary.User;
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

    
    public async Task<PassResponse> CreatePass(CreatePassRequest createPassRequest)
    {
        var user = GetUserByNationalIdAsync(createPassRequest.NationalId).Result;
        if (user == null)
        {
            return null;
        }
     
        var createPass = _mapper.Map<PassDao>(createPassRequest);
        createPass.UserId = user.Id;
        createPass.IsApproved = false;
        createPass.IsValid = false;
        createPass.GeneratedDateTime = DateTime.Now;

        _context.Passes.Add(createPass);
       var saveChanges =  await _context.SaveChangesAsync();
       if (saveChanges > 0)
       {
           return _mapper.Map<PassResponse>(createPass);
       }
       
       return null;
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
            .FirstOrDefaultAsync(x => x.Id == Guid);;
        return pass;
    }

    public async Task<UserDao?> GetUserByNationalIdAsync(string nationalId)
    {
        var firstOrDefaultAsync = await _context.Users.AsNoTracking().Where(user => user.NationalId == nationalId).AsNoTracking()
            .FirstOrDefaultAsync();

        if (firstOrDefaultAsync == null)
        {
            
        }
        return firstOrDefaultAsync;
    }
}