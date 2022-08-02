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


    public PassService(DBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet(PassApiRoutes.Pass.GetAll)]
    public async Task<PagedResponse<PassResponse>> Get(PaginationFilter pagination)
    {
        var queryable = _context.Passes.AsNoTracking();
        var pagedResponse = await PagedResponse<PassDao>.ToPagedList(queryable, pagination);
        return MappingHelper.MapPagination<PassResponse, PassDao>(pagedResponse, _mapper);
    }

    [HttpPost(PassApiRoutes.Pass.Create)]
    public async Task<PassResponse> CreatePass(CreatePassRequest createPassRequest)
    {
        var pass = _mapper.Map<PassDao>(createPassRequest);
        _context.Passes.Add(pass);
        await _context.SaveChangesAsync();

        return _mapper.Map<PassResponse>(pass);
    }
}