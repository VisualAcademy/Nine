//[?] C# 9.0 New Features + Microsoft Docs
//[1] Top Level Statements
using System.Threading.Tasks;
System.Console.WriteLine($"Hello {args[0]}, Happy Coding!!!");
await Task.Delay(1000);

//[2] Init Accessors
var sponsor = new Sponsor { Id = 1, DisplayName = "Red" }; //sponsor.DisplayName = "RedPlus"; // mutable => init => immutable
DisplayData(sponsor);
static void DisplayData(Sponsor sponsor) =>
    System.Console.WriteLine($"{sponsor.Id} - {sponsor.DisplayName}");

//[3] Records
var subscriber = new Subscriber("Visual", 3, true);
var vip = subscriber with { Title = "VIP" };
System.Console.WriteLine(vip);
var (title, duration, isAvailable) = subscriber; // Deconstruct()
System.Console.WriteLine($"{title} - {duration} - {isAvailable}");

//[4] Pattern Matching 
//Subscriber membership = new Visual("VIP", 1, true); //[C]
//Subscriber membership = new Studio("Sponsor", 2, true); //[B]
Subscriber membership = new Code("Champion", 2, true); //[A]
var membershipDescription = membership switch
{
    // Pattern => Expression
    ("Champion", var d, var i) => $"Champion - {d} - {i}",

    //[A] Champion(Code)
    Code c when c.Duration > 1 => $"{c.Title} Membership > 1",
    Code c => $"{c.Title} Membership",

    //[B] Sponsor(Studio)
    (Code and (_, > 1, true)) or (Studio and { Duration: 2 }) => "Multi", //[6] Parenthesized Pattern
    Studio and (_, > 1, _) => "Sponsor Membership > 1", //[5] Relational Pattern
    Studio => "Sponsor Membership", //[2] Type Pattern 

    //[C] VIP(Visual)
    Visual and { Title: "VIP" } => "VIP Membership", //[4] Property Pattern
    Visual and (_, 1, true) => "Welcome VIP", //[3] Positional Pattern
    not Visual => "No Problem", //[2] Type Pattern + not 
    _ => "No Membership" //[1] Discard == Default Case
};
System.Console.WriteLine(membershipDescription);

class Sponsor
{
    public int Id { get; init; }
    public string DisplayName { get; init; }
}

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
