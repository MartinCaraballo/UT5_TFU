namespace UT5_TFU.Contracts.Athletes;

public record UpsertAthleteRequest(
    string Id,
    string Name,
    string Discipline
);