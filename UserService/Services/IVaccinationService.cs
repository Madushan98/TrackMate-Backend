using DTOLibrary.VaccinationDataDto;

namespace UserService.Services;

public interface IVaccinationService
{
   Task<List<VaccinationDataResponse>> GetUserVaccinationDetailList(Guid userId); 
   Task<VaccinationDataResponse> CreateUserVaccinationDetails(VaccinationDataCreateRequest vaccinationDataCreateRequest);
   
}