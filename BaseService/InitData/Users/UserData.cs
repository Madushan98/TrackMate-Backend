using BaseService.Constants;
using DAOLibrary.User;

namespace Base.InitData.Users;

public class UserData : BaseDataInit<UserDao>
{
    private const string Pass = "KcsI7gpDcpIWTwuCQUIvDA==";
    private const string Key = "S6yeuQw4VMYmzvTapS/Jph3oUct88Iqq0XprXWxfMpQ=";
    private const string Iv = "Qn0j+NTJFfCQ2Hw6WdjXqA==";

    public override List<UserDao> Data()
    {
        return new List<UserDao>()
        {
            new UserDao()
            {
                Id = Constants.AdminUserId,
                NationalId = Constants.AdminNationalId,
                FullName = "Admin",
                IsVertified = true,
                UserType = Constants.UserTypes[Constants.AdminUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                NationalId = Constants.UserNationalId,
                FullName = "User",
                IsVertified = true,
                UserType = Constants.UserTypes[Constants.UserUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                NationalId = Constants.ScannerNationalId,
                FullName = "Scanner",
                IsVertified = true,
                UserType = Constants.UserTypes[Constants.ScannerUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
        };

    }

}