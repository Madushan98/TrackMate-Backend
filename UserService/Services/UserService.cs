﻿using AutoMapper;
using BaseService.DataContext;
using DAOLibrary.Organization;
using DTOLibrary.OrganizationDto;
using DTOLibrary.UserDto.AddOrganization;
using Microsoft.EntityFrameworkCore;

namespace UserService.Services;

public class UserService : IUserService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;

    public UserService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<UpdateUserOrganizationResponse> UpdateUserOrganization(UpdateUserOrganizationRequest request)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == request.UserId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var organization = await _context.Organizations.AsNoTracking()
            .FirstOrDefaultAsync(organization => organization.Id == request.OrganizationId);

        user.Organization = organization;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return new UpdateUserOrganizationResponse()
        { 
            Message = "Organization Details Is submitted",
        };
  
    }
}