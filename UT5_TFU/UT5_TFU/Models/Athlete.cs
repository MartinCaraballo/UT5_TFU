namespace UT5_TFU.Models;

public class Athlete
{
    public string Id { get;}
    public string Name { get;}
    public string Discipline { get;}

    public Athlete(string id, string name, string discipline)
    {
        this.Id = id;
        this.Name = name;
        this.Discipline = discipline;
    }
}