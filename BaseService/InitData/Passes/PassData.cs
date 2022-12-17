using BaseService.Constants;
using DAOLibrary.Pass;

namespace Base.InitData.Passes;

public class PassData : BaseDataInit<PassDao>
{
    public override List<PassDao> Data()
    {
        return new List<PassDao>()
        {
            new PassDao()
            {
                Id = Constants.PassId,
                GeneratedDateTime = DateTime.UtcNow,
                IsReoccurring = false,
                From = "Rathnapura",
                To = "Colombo",
                PassCategory = "Employee",
                Data = new List<PassDataMap>(),
                IsValid = true,
                IsApproved = true,
                UserId = Constants.AdminUserId,
                NationalId = Constants.AdminNationalId
            },
        };
    }
}