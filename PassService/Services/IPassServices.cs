
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto;

namespace PassService.Services;

public interface IPassServices
{
    Task<PagedResponse<PassResponse>> Get(PaginationFilter pagination);
    Task<PassResponse> CreatePass(CreatePassRequest createPassRequest);
    
}