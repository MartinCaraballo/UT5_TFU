namespace UT5_TFU.Contracts.Athletes;

public record CreateAthleteRequest(
    string Id,
    string Name,
    string Discipline
);