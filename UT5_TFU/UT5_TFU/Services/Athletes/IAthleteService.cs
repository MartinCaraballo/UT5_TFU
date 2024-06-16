using UT5_TFU.Contracts.Athletes;
using UT5_TFU.Models;
using ErrorOr;

namespace UT5_TFU.Services.Athletes;

public interface IAthleteService
{
    ErrorOr<Created> CreateAthlete(Athlete athlete);
    ErrorOr<Athlete> GetAthlete(string id);
    ErrorOr<UpsertedAthlete> UpsertAthlete(Athlete athlete);
    ErrorOr<Deleted> DeleteAthlete(string id);

}