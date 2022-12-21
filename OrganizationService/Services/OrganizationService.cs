using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Claims;
using AutoMapper;
using BaseService.Constants;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.Organization;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using DTOLibrary.OrganizationDto.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

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

    public async Task<OrganizationLoginResponse> CreateOrganization(CreateOrganizationRequest organizationRequest)
    {
        
        bool checkExists = await IsOrganizationExists(organizationRequest);
        if (checkExists)
        {
            throw new ValidationException("Organization is already registered");
        }
        var organizationDao = _mapper.Map<OrganizationDao>(organizationRequest);
        var (encryptedPassword, key, iv) = _cryptoService.Encrypt(organizationRequest.Password);
        organizationDao.IsApproved = false;
        organizationDao.Iv = iv;
        organizationDao.Key = key;
        organizationDao.Password = encryptedPassword;
        organizationDao.UserType = Constants.UserTypes[Constants.UserOrganizationRole];
        var organization = await _context.Organizations.AddAsync(organizationDao);
        var organizationResponse = _mapper.Map<OrganizationResponse>(organizationDao);
        var saveAsync = await _context.SaveChangesAsync();
        var refreshToken = Guid.NewGuid().ToString();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, organizationDao.EmailAddress),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", organization.Entity.Id.ToString()),
            new Claim("Username", organizationDao.EmailAddress),
            new Claim("Permission", string.Join(",", new List<int>())),
            new Claim("UserType",organizationDao.UserType )
        };
        return _tokenService.GenerateOrganizationAuthenticationResult(organization.Entity.Id.ToString(), claims,
            refreshToken, organizationResponse);
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

    private async Task<bool> IsOrganizationExists(CreateOrganizationRequest organizationRequest)
    {
        if (string.IsNullOrEmpty(organizationRequest.EmailAddress))
        {
            return false;
        }

        var firstOrDefault =await _context.Organizations.AsNoTracking()
            .Where(org => org.EmailAddress.Equals(organizationRequest.EmailAddress)).FirstOrDefaultAsync();
        return firstOrDefault != null;
    }
    
}