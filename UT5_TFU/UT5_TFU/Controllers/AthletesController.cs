using Microsoft.AspNetCore.Mvc;
using UT5_TFU.Contracts.Athletes;
using UT5_TFU.Models;
using UT5_TFU.Services.Athletes;
using ErrorOr;
using UT5_TFU.ServiceErrors;

namespace UT5_TFU.Controllers;

public class AthleteController : ApiController
{
    private readonly IAthleteService _athleteService;

    public AthleteController(IAthleteService athleteService)
    {
        _athleteService = athleteService;
    }

    [HttpPost]
    public IActionResult CreateAthlete(CreateAthleteRequest request)
    {
        var athlete = new Athlete(
            request.Id,
            request.Name,
            request.Discipline);

        ErrorOr<Created> createdAthleteResult =_athleteService.CreateAthlete(athlete); 

        return createdAthleteResult.Match(
            created => CreatedAtGetAthlete(athlete),
            errors => Problem(errors));
    }


    [HttpGet("{id}")]
    public IActionResult GetAthlete(string id)
    {
        ErrorOr<Athlete> getAthleteResult = _athleteService.GetAthlete(id);

        return getAthleteResult.Match(
            athlete => Ok(MapAthleteResponse(athlete)),
            errors => Problem(errors));
        /* if (getAthleteResult.IsError && getAthleteResult.FirstError == Errors.Athlete.NotFound)
        {
            return NotFound();
        }

        var athlete = getAthleteResult.Value;

        return Ok(response); */
    }

    [HttpPut("{id}")]
    public IActionResult UpsertAthlete(string id, UpsertAthleteRequest request)
    {
        var athlete = new Athlete(
            id,
            request.Name,
            request.Discipline);

        ErrorOr<UpsertedAthlete> upsertedAthleteResult = _athleteService.UpsertAthlete(athlete);

        return upsertedAthleteResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetAthlete(athlete) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAthlete(string id)
    {
        ErrorOr<Deleted> deletedAthleteResult = _athleteService.DeleteAthlete(id);

        return deletedAthleteResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static AthleteResponse MapAthleteResponse(Athlete athlete)
    {
        return new AthleteResponse(
            athlete.Id,
            athlete.Name,
            athlete.Discipline);
    }
    
    private CreatedAtActionResult CreatedAtGetAthlete(Athlete athlete)
    {
        return CreatedAtAction(
            nameof(GetAthlete),
            new { id = athlete.Id},
            value: MapAthleteResponse(athlete));
    }
}