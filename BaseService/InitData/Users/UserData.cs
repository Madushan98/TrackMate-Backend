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
                IsVertified = Constants.VerificationStatus[Constants.Verified],
                UserType = Constants.UserTypes[Constants.AdminUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-121111112112"),
                NationalId = "9812345678",
                FullName = "Chathura Nuwan",
                IsVertified = Constants.VerificationStatus[Constants.NotVerified],
                UserType = Constants.UserTypes[Constants.UserUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                NationalId = Constants.UserNationalId,
                FullName = "User",
                IsVertified = Constants.VerificationStatus[Constants.Verified],
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
                IsVertified = Constants.VerificationStatus[Constants.Verified],
                UserType = Constants.UserTypes[Constants.ScannerUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111112213"),
                NationalId = "9843211234",
                FullName = "Achila Sandeep",
                IsVertified = Constants.VerificationStatus[Constants.Pending],
                UserType = Constants.UserTypes[Constants.UserUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111412213"),
                NationalId = "9843211334",
                FullName = "Achila Nuwan",
                IsVertified = Constants.VerificationStatus[Constants.Pending],
                UserType = Constants.UserTypes[Constants.UserUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
            new UserDao()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111151112213"),
                NationalId = "9842211234",
                FullName = "Chathura Sandeep",
                IsVertified = Constants.VerificationStatus[Constants.Pending],
                UserType = Constants.UserTypes[Constants.UserUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
        };

    }

}