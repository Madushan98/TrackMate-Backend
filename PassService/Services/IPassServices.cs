
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.Filters;
using DTOLibrary.UserDto;

namespace PassService.Services;

public interface IPassServices
{
    Task<PagedResponse<PassResponse>> GetAllPass(PassFilter filter, PaginationFilter pagination);
    Task<PassResponse> CreatePass(CreatePassRequest passRequest);
    string CreatePassToke(string passId);
    public Task<PassDao> GetScanData(string token);

}