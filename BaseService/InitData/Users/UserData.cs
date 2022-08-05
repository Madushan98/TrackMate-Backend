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
                FirstName = "Admin",
                LastName = "Admin",
                IsVertified = true,
                UserType = Constants.UserTypes[Constants.AdminUserRole],
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
        };

    }

}