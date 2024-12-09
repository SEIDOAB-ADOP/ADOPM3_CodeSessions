using Seido.Utilities.SeedGenerator;

namespace _01_Enumerable.Models;

public enum FriendLevel { Friend, ClassMate, Family, BestFriend }
public class Friend
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }

    public string Email { get; init; }
    public FriendLevel Level { get; init; }

    public Car Car { get; init; }
        

    public override string ToString()
    {
        var sRet = $"{FirstName} {LastName} is my {Level} and can be reached at {Email}. {Age} years old.";
        if (Car != null)
        {
            sRet += $"\n -{FirstName}'s car is a {Car.Color} {Car.Brand} {Car.Model} from year {Car.YearModel}";
        }
        return sRet;
    }

    public Friend Seed(SeedGenerator seeder)
    {
        string _firstName = seeder.FirstName;
        string _lastName = seeder.LastName;

        return new Friend() {
            FirstName = _firstName,
            LastName = _lastName,

            Email = seeder.Email(_firstName, _lastName),
            Level = seeder.FromEnum<FriendLevel>(),
            Age = seeder.Next(5, 35),
            Car = new Car().Seed(seeder) };
    }
}
