using AuthService.Domain.Filters;
using AutoMapper;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.Organization;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.Helpers;
using DTOLibrary.OrganizationDto;
using DTOLibrary.UserDto;
using Microsoft.EntityFrameworkCore;

namespace OrganizationService.Services;


public class OrganizationService : IOrganizationService

{
    private readonly DBContext _context;
    private readonly IMapper _mapper;


    public OrganizationService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PagedResponse<OrganizationDao>>  GetAllOrganization(PaginationFilter pagination)
    {
        var queryable = _context.Organizations.AsNoTracking();
        var pagedResponse = await PagedResponse<OrganizationDao>.ToPagedList(queryable, pagination);
        return pagedResponse;
    }

  
    
    public Task<OrganizationDao> GetOrganizationById(Guid id)
    {
        var organization =_context.Organizations.FirstOrDefaultAsync(dao => dao.Id == id);
        
        return organization;
    }

    public async Task<OrganizationResponse?> UpdateOrganization(Guid id, UpdateOrganizationRequest request)
    {
        var exists = await _context.Organizations.AsNoTracking().
            FirstOrDefaultAsync(org => org.Id == id);
        if (exists == null)
        {
            return null;
        }

        var organizationDao = _mapper.Map<OrganizationDao>(request);
        organizationDao.Iv = exists.Iv;
        organizationDao.Password = exists.Password;
        organizationDao.Key = exists.Key;
        _context.Organizations.Update(organizationDao);
        var saveAsyncChange =await _context.SaveChangesAsync();
        if (saveAsyncChange > 0)
        {
            var organizationById = await _context.Organizations.AsNoTracking().
                FirstOrDefaultAsync(org => org.Id == id);
            return _mapper.Map<OrganizationResponse>(organizationById);
        }

        return null;
    }

    public async Task<bool> DeleteById(Guid id)
    {
        var organization = await _context.Organizations
            .FirstOrDefaultAsync(pass=>pass.Id == id);

        _context.Organizations.Remove(organization);
        
        var saveChangesAsync = await _context.SaveChangesAsync();
        return saveChangesAsync > 0;
    }
    
    public async Task<UserResponse> GetUserByIdAsync(Guid userId)
    {
        var result = await GetUserDaoByIdAsync(userId);
        var userResponse = _mapper.Map<UserResponse>(result);
        return userResponse;
    }
    
    

    public async Task<PagedResponse<UserResponse>> GetAllUsersAsync(UserFilter filter,
        PaginationFilter pagination)
    {
        var queryable = _context.Users.AsNoTracking();

        queryable = AddFilterOnQuery(filter, queryable);

        var pagedResponse = await PagedResponse<UserDao>.ToPagedList(queryable, pagination);
        return MappingHelper.MapPagination<UserResponse, UserDao>(pagedResponse, _mapper);
    }

    public async Task<PagedResponse<UserResponse>> GetUserByOrganizationIdAsync(Guid id, PaginationFilter paginationFilter)
    {
        var queryable = _context.Users.AsNoTracking().Where(user=>user.OrganizationId == id);
        var pagedResponse = await PagedResponse<UserDao>.ToPagedList(queryable, paginationFilter);
        return MappingHelper.MapPagination<UserResponse, UserDao>(pagedResponse, _mapper);
    }

    public async Task<UserResponse> UpdateUserByIdAsync(Guid id, UserUpdateRequest request)
    {
        var exists = await _context.Users.
            FirstOrDefaultAsync(user => user.Id == id);
        if (exists == null)
        {
            return null;
        }

        exists.IsVertified = request.IsVertified;
        var saveAsyncChange =await _context.SaveChangesAsync();
        if (saveAsyncChange > 0)
        {
            var userById = await _context.Users.AsNoTracking().
                FirstOrDefaultAsync(org => org.Id == id);
            return _mapper.Map<UserResponse>(userById);
        }

        return null;
    }

    private IQueryable<UserDao> AddFilterOnQuery(UserFilter filter, IQueryable<UserDao> queryable)
    {
        if (Guid.Empty != filter?.UserId)
        {
            queryable = queryable.Where(user => user.Id == filter.UserId);
        }

        if (!string.IsNullOrEmpty(filter?.NationalId))
        {
            queryable = queryable.Where(user => user.NationalId.StartsWith(filter.NationalId));
        }

        return queryable;
    }
    
    private async Task<UserDao?> GetUserDaoByIdAsync(Guid userId)
    {
        var user  = await  _context.Users
            .AsNoTracking()
            .Include(user=>user.VaccinationData)
            .FirstOrDefaultAsync(user => user.Id == userId);
        return user;
    }
}