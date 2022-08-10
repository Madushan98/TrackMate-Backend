using BaseService.Constants;
using DAOLibrary.User;

namespace Base.InitData.Users;

public class UserData : BaseDataInit<UserDao>
{
    private const string Pass = "hUSqSs18RSXUGvqmpJ0Bvg==";
    private const string Key = "jXaTiycDZAwJJ5V0845dZzV42//c9aRiYDtixz/VzUc=";
    private const string Iv = "nRAnoIEBItu67NxD/ftlMg==";

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
                NationalId = "988888888",
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
                NationalId = "988888188",
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