using AutoMapper;
using BaseService.DataContext;
using BaseService.Services;
using DAOLibrary.Pass;
using DTOLibrary.Common;
using DTOLibrary.PassLogDto;
using Microsoft.EntityFrameworkCore;

namespace PassService.Services;

public class PassLogService : IPassLogService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly ICryptoService _cryptoService;
    private readonly ITokenService _tokenService;


    public PassLogService(DBContext context, IMapper mapper, ICryptoService cryptoService, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _cryptoService = cryptoService;
        _tokenService = tokenService;
    }

    public async Task<PassLogEncryptDao> SavePassLog(CreatePassLogRequest createPassLogRequest)
    {
        var user = _context.Users.AsNoTracking().FirstOrDefault(user => user.Id == createPassLogRequest.UserId);
        PassLogEncryptDao passLogEncryptDao = new PassLogEncryptDao();
        var longitude = _cryptoService.EncryptLogData(createPassLogRequest.Longitude.ToString(), user.Key, user.Iv);
        var lattiutde = _cryptoService.EncryptLogData(createPassLogRequest.Latitude.ToString(), user.Key, user.Iv);

        passLogEncryptDao.Latitude = lattiutde;
        passLogEncryptDao.Longitude = longitude;
        passLogEncryptDao.UserNatId = user.NationalId;
        passLogEncryptDao.UserId = user.Id;
        passLogEncryptDao.ScannerId = createPassLogRequest.ScannerId;
        passLogEncryptDao.LogTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        passLogEncryptDao.Date = DateTime.Now.ToString("MM/dd/yyyy");
        passLogEncryptDao.PassId = createPassLogRequest.PassId;

        _context.PassLogEncrypts.Add(passLogEncryptDao);
        await _context.SaveChangesAsync();
        return passLogEncryptDao;
    }


    public async Task<List<PassLogDao>> GetPassLogByPassId(Guid passId)
    {
        List<PassLogDao> passLogDaos = new List<PassLogDao>();

        return passLogDaos;
    }

    public async Task<List<PassLogDao>> GetPassLogByUserId(Guid userId)
    {
        var encryptPassLogList = _context.PassLogEncrypts.AsNoTracking().Where(dao => dao.UserId == userId).ToList();
        var user = _context.Users.AsNoTracking().FirstOrDefault(user => user.Id == userId);

        List<PassLogDao> passLogDaos = new List<PassLogDao>();

        foreach (var passLogEncryptDao in encryptPassLogList)
        {
            var longitude = _cryptoService.Decrypt(passLogEncryptDao.Latitude, user.Key, user.Iv);
            var lattiutde = _cryptoService.Decrypt(passLogEncryptDao.Longitude, user.Key, user.Iv);

            passLogDaos.Add(
                new PassLogDao()
                {
                    LogTime = passLogEncryptDao.LogTime,
                    Longitude = Decimal.Parse(longitude),
                    Latitude = Decimal.Parse(lattiutde),
                    PassId = passLogEncryptDao.PassId,
                    ScannerId = passLogEncryptDao.ScannerId,
                    Date = passLogEncryptDao.Date,
                    UserId = passLogEncryptDao.UserId,
                    UserNatId = passLogEncryptDao.UserNatId
                }
            );
        }


        return passLogDaos;
    }

    public async Task<List<PassLogDao>> GetPassLogByUserIdAndDate(Guid userId, DateTime dateTime)
    {
        string date = dateTime.ToString("MM/dd/yyyy");
        Console.WriteLine("Date    " + date);
        var loglist = _context.PassLogs.Where(dao => (dao.UserId == userId && dao.Date == date)).ToList();
        return loglist;
    }

    public async Task<List<PassLogDao>> GetPassLogByScannerId(Guid ScannerId)
    {
        var encryptPassLogList = _context.PassLogEncrypts.AsNoTracking().Where(dao => dao.ScannerId == ScannerId).ToList();
        
        List<PassLogDao> passLogDaos = new List<PassLogDao>();

        foreach (var passLogEncryptDao in encryptPassLogList)
        {
           
            passLogDaos.Add(
                new PassLogDao()
                {
                    LogTime = passLogEncryptDao.LogTime,
                    PassId = passLogEncryptDao.PassId,
                    ScannerId = passLogEncryptDao.ScannerId,
                    Date = passLogEncryptDao.Date,
                    UserId = passLogEncryptDao.UserId,
                    UserNatId = passLogEncryptDao.UserNatId
                }
            );
        }
        
        return passLogDaos;
    }
}