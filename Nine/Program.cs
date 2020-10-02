//[1] Top Level Statements
using System.Threading.Tasks;
System.Console.WriteLine($"Hello {args[0]}, Happy Coding!!!");
await Task.Delay(1000);

var sponsor = new Sponsor { Id = 1, DisplayName = "Red" }; //sponsor.DisplayName = "RedPlus"; // mutable => init => immutable
DisplayData(sponsor);
static void DisplayData(Sponsor sponsor) =>
    System.Console.WriteLine($"{sponsor.Id} - {sponsor.DisplayName}");

var subscriber = new Subscriber("Visual", 3, true);
var vip = subscriber with { Title = "VIP" };
System.Console.WriteLine(vip);
var (title, duration, isAvailable) = subscriber; // Deconstruct()
System.Console.WriteLine($"{title} - {duration} - {isAvailable}");

//[2] Init Accessors
class Sponsor
{
    public int Id { get; init; }
    public string DisplayName { get; init; }
}

//[3] Records
//record Subscriber
//{
//    public string Title { get; init; }
//    public int Duration { get; init; }
//}
record Subscriber(string Title, int Duration, bool IsAvariable); // Syntax Sugar
record Visual(string Title, int Duration, bool IsAvariable)
    : Subscriber(Title, Duration, IsAvariable);
record Studio : Subscriber
{
    public Studio(string Title, int Duration, bool IsAvariable) :
        base(Title, Duration, IsAvariable)
    { }
}
record Code : Subscriber
{
    public Code(string Title, int Duration, bool IsAvariable) :
        base(Title, Duration, IsAvariable)
    { }
}
