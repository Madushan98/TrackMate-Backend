using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using Microsoft.EntityFrameworkCore;

namespace OrganizationService.Services;


public class OrganizationService : IOrganizationService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;


    public OrganizationService(DBContext context, IMapper mapper )
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

    public async Task<OrganizationDao> CreateOrganization(OrganizationDao organizationDao)
    {
       var organization =  _context.Organizations.Add(organizationDao);
        await _context.SaveChangesAsync();
        return organization.Entity;
    }

    public Task<OrganizationDao> GetOrganizationById(Guid id)
    {
        var organization =_context.Organizations.FirstOrDefaultAsync(dao => dao.Id == id);
        
        return organization;
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