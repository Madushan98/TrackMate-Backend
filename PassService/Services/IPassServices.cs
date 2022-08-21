
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.PassDto.PassToken;
using DTOLibrary.UserDto;

namespace PassService.Services;

public interface IPassServices
{
    Task<PagedResponse<PassDao>> GetAllPass(PaginationFilter pagination);
    Task<PassDao> CreatePass(PassDao passDao);
    Task<PassTokenResponse> CreatePassToke(Guid passId);
    Task<PassResponse> GetScanData(string token);
    Task<PassDao?> GetPassById(Guid id);
    Task<bool> DeleteById(Guid id);
    Task<List<PassDao>> GetPassByUserId(Guid userId);

}