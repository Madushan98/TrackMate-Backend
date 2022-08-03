
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto;

namespace PassService.Services;

public interface IPassServices
{
    Task<PagedResponse<PassDao>> GetAllPass(PaginationFilter pagination);
    Task<PassDao> CreatePass(PassDao passDao);
    string CreatePassToke(Guid passId);
    Task<PassDao> GetScanData(string token);
    Task<PassDao> GetPassById(Guid id);

}