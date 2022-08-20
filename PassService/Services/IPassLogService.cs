using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassLogDto;

namespace PassService.Services;

public interface IPassLogService
{
    Task<PassLogDao> SavePassLog(PassLogDao passLogDao);
    
    Task<List<PassLogDao>> GetPassLogByPassId(Guid passId);

}