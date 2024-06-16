using UT5_TFU.Models;
using ErrorOr;
using UT5_TFU.ServiceErrors;

namespace UT5_TFU.Services.Athletes;

public class AthleteService : IAthleteService
{
    private static readonly Dictionary<string, Athlete> _athletes = new();
    public ErrorOr<Created> CreateAthlete(Athlete athlete)
    {
        _athletes.Add(athlete.Id, athlete);

        return Result.Created;
    }

    public ErrorOr<Athlete> GetAthlete(string id)
    {
        if (_athletes.TryGetValue(id, out var athlete))
        {
            return athlete;
        }

        return Errors.Athlete.NotFound;
    }

    public ErrorOr<UpsertedAthlete> UpsertAthlete(Athlete athlete)
    {
        var IsNewlyCreated = !_athletes.ContainsKey(athlete.Id);
        _athletes[athlete.Id] = athlete;

        return new UpsertedAthlete(IsNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteAthlete(string id)
    {
        _athletes.Remove(id);

        return Result.Deleted;
    }
}