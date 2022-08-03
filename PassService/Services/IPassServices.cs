
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto;

namespace PassService.Services;

public interface IPassServices
{
    Task<PagedResponse<PassResponse>> GetAllPass(PaginationFilter pagination);
    Task<PassResponse> CreatePass(PassDao passDao);
    string CreatePassToke(string passId);
    public string VerifyPass(string token);

}