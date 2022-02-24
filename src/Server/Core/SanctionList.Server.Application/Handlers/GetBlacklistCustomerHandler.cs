using MediatR;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Application.Handlers.FuzzyNameFinder;
using SanctionList.Server.Domain.DowJones;
using SanctionList.Shared.Dto.Queries;
using SanctionList.Shared.Dto.Responses;

namespace SanctionList.Server.Application.Handlers;

public class GetBlackListCustomerHandler : IRequestHandler<GetBlacklistedCustomerQuery, IEnumerable<BlacklistedCustomerResponse>>
{
    private readonly IDowJonesIdentityRepo _repo;
    private readonly IMatchingCriteriaRepo _criteriaRepo;
    private readonly LevenshteinByPartition _levenshtein;

    public GetBlackListCustomerHandler(IDowJonesIdentityRepo repo, LevenshteinByPartition levenshtein, IMatchingCriteriaRepo criteriaRepo)
    {
        _repo = repo;
        _levenshtein = levenshtein;
        _criteriaRepo = criteriaRepo;
    }

    public async Task<IEnumerable<BlacklistedCustomerResponse>> Handle(GetBlacklistedCustomerQuery request, CancellationToken cancellationToken)
    {
        var criteria = await _criteriaRepo.Get();
        var identityNames = (await _levenshtein.Match(request.Name, criteria.ReturnOnMatchRatio)).ToList();
        var blacklistedCustomers = new List<BlacklistedCustomerResponse>();

        var uniqueIds = identityNames.Select(n => n.identityName.IdentityId).Distinct();

        var identities = await _repo.Get(uniqueIds);
        foreach (var identity in identities)
        {
            var matchedIdentityNames = identityNames.FindAll(n => n.identityName.IdentityId == identity.Id);
            blacklistedCustomers.Add(new ()
            {
                DowJonesId = identity.DowJonesId,
                IdNo = identity.IdNo,
                IdType = identity.IdType,
                Gender = identity.Gender,
                IndOrg = identity.IdentityType,
                Dob = identity.Dob,
                HasSanction = identity.HasSanction,
                HasOccupation = identity.HasOccupation,
                HasRelationship = identity.HasRelationship,
                HasOtherList = identity.HasOtherList,
                IsActive = identity.IsActive,
                Citizenship = identity.Citizenship,
                MatchedNames = GetMatchedNames(matchedIdentityNames)
            });
        }

        return blacklistedCustomers;
    }

    private List<BlacklistedMatch> GetMatchedNames(List<(DowJonesIdentityName matchedName, int matchScore)> matchResults)
    {
        var matches = new List<BlacklistedMatch>();
        foreach (var result in matchResults)
        {
            matches.Add(new ()
            {
                Name = result.matchedName.Name,
                NameType = result.matchedName.NameType,
                MatchRatio = result.matchScore
            });
        }

        return matches;
    }
}