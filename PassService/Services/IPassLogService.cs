using DAOLibrary.Pass;
using DTOLibrary.PassLogDto;

namespace PassService.Services;

public interface IPassLogService
{
    Task<PassLogDao> SavePassLog(PassLogDao passLogDao);

}