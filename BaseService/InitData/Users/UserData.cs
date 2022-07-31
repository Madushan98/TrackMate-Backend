using BaseService.Constants;
using DAOLIbrary.User;

namespace Base.InitData.Users;

public class UserData : BaseDataInit<User>
{
    private const string Pass = "hUSqSs18RSXUGvqmpJ0Bvg==";
    private const string Key = "jXaTiycDZAwJJ5V0845dZzV42//c9aRiYDtixz/VzUc=";
    private const string Iv = "nRAnoIEBItu67NxD/ftlMg==";

    public override List<User> Data()
    {
        return new List<User>()
        {
            new User()
            {
                UserId = Constants.AdminUserId,
                NationalId = Constants.AdminNationalId,
                FirstName = "Admin",
                LastName = "Admin",
                IsVertified = true,
                Password = Pass,
                Key = Key,
                Iv = Iv
            },
        };

    }

}