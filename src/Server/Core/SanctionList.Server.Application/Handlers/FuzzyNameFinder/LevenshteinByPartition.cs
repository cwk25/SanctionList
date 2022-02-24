using FuzzySharp;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.DowJones;

namespace SanctionList.Server.Application.Handlers.FuzzyNameFinder;

public class LevenshteinByPartition
{
    private readonly IDowJonesIdentityNameRepo _repo;

    public LevenshteinByPartition(IDowJonesIdentityNameRepo repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<(DowJonesIdentityName identityName, int score)>> Match(string name, int ratio)
    {
        name = name.ToUpper();
        var names = name.Split(' ');
        var matchNames = new List<(DowJonesIdentityName, int)>();
        foreach (var word in names)
        {
            var blacklistedNames = await _repo.GetByPartition(word[0]);
            foreach (var blacklistedName in blacklistedNames)
            {
                var matchScore = Fuzz.Ratio(name, blacklistedName.Name);
                if (matchScore < ratio)
                    continue;

                matchNames.Add((blacklistedName, matchScore));
            }
        }

        return matchNames;
    }
}