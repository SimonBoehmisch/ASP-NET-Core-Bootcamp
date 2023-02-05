using LinqCheatsheet.Models;
using System.Runtime.CompilerServices;

#region Lawyers
var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "John",
        LastName = "Doe"
    },
    new Lawyer()
    {
        FirstName = "Heinrich",
        LastName = "Schweiger"
    }
};
#endregion

#region Clients
var clients = new[]
{
    new Client()
    {
        FirstName = "Tim",
        LastName = "Funny"
    },
    new Client()
    {
        FirstName = "Jim",
        LastName = "Decker"
    },
    new Client()
    {
        FirstName = "Yana",
        LastName = "Cat"
    }
};
#endregion

#region Cases
var cases = new[]
{
    new Case()
    {
        Title = "Car accident",
        AmountInDispute = 100000,
        CaseType = CaseType.Commercial,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Molding flat",
        AmountInDispute = 65000,
        CaseType = CaseType.Commercial,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Death thread",
        AmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        Client = clients[1],
        Lawyer = lawyers[1]
    },
    new Case()
    {
        Title = "Robbery",
        AmountInDispute = 1500,
        CaseType = CaseType.ProBono,
        Client = clients[1],
        Lawyer = lawyers[1]
    }
};
#endregion

#region Where
foreach (Lawyer lawyer in lawyers)
{
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();
}
foreach (Client client in clients)
{
    client.Cases = cases.Where(c => c.Client == client).ToList();
}
#endregion

#region First and Single
var workingFirstExample = lawyers.First(l => l.FirstName == "John");

try
{
    var firstExceptionExample = lawyers.First(l => l.FirstName == "Joh");

}
catch (Exception)
{
    Console.WriteLine("Invalid operation exception has been thrown, no matching elments found.");
}

var firstOrDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Joh");

//Single works like First, but ensures that only a single element matches the specified condition
var workingSingleExample = lawyers.Single(l => l.FirstName == "John");

try
{
    var singleExceptionExample = lawyers.Single(l => l.LastName.Contains("e"));
}
catch (Exception)
{

    Console.WriteLine("Invalid operation exception has been thrown, more than one element matches the condition");
}

var singleOrDefaultExample = lawyers.SingleOrDefault(l => l.FirstName == "Joh");

#endregion

#region Any and All
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(c => c.CaseType == CaseType.ProBono));

var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial));
#endregion

#region Working with Numbers

var sumOfAmountInDispute = cases.Sum(c => c.AmountInDispute);
var averageAmountInDispute = cases.Average(c => c.AmountInDispute);
var maxAmountInDispute = cases.Max(c => c.AmountInDispute);
var minAmountInDispute = cases.Min(c => c.AmountInDispute);

#endregion

#region OrderBy and Ascending

var lawyersByAmountInDisputeAsc = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmountInDispute));
var lawyersByAmountInDisputeDesc = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmountInDispute));

#endregion

#region Select

var caseTitles = cases.Select(c => c.Title);
var lawyerNames = lawyers.Select(l => l.FirstName + "," + l.LastName);

var casesPerLawyer = lawyers.Select(l => l.Cases);

//SelectMany returns a flattened list
var casesPerLawyerFlat = lawyers.SelectMany(l => l.Cases);

#endregion

#region Fluent - Chaining Linq Queries

var caseTitlesOfCommercialLawyers = lawyers
    .Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial))
    .SelectMany(l => l.Cases)
    .Select(c => c.Title);

#endregion


Console.ReadLine();