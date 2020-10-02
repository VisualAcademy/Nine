//[1] Top Level Statements
using System.Threading.Tasks;
System.Console.WriteLine($"Hello {args[0]}, Happy Coding!!!");
await Task.Delay(3000);

var sponsor = new Sponsor { Id = 1, DisplayName = "Red" }; //sponsor.DisplayName = "RedPlus"; // mutable => init => immutable

DisplayData(sponsor); 

static void DisplayData(Sponsor sponsor) => 
    System.Console.WriteLine($"{sponsor.Id} - {sponsor.DisplayName}");

struct Sponsor
{
    public int Id { get; init; }
    public string DisplayName { get; init; }
}
