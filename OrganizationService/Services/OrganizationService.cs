using AutoMapper;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.Organization;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using Microsoft.EntityFrameworkCore;

namespace OrganizationService.Services;


public class OrganizationService : IOrganizationService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly ICryptoService _cryptoService;
    private readonly ITokenService _tokenService;


    public OrganizationService(DBContext context, IMapper mapper, ICryptoService cryptoService, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _cryptoService = cryptoService;
        _tokenService = tokenService;
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
    
    
}