using ErrorOr;
namespace UT5_TFU.ServiceErrors;

public static class Errors
{
    public static class Athlete
    {
        public static Error NotFound => Error.NotFound(
            code: "Athlete.NotFound",
            description: "Athlete not found");
    }
}