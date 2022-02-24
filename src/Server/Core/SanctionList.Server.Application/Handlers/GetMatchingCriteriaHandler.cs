using MediatR;
using SanctionList.Server.Application.Contracts;
using SanctionList.Shared.Dto.Queries;
using SanctionList.Shared.Dto.Responses;

namespace SanctionList.Server.Application.Handlers;

public class GetMatchingCriteriaHandler : IRequestHandler<GetMatchingCriteriaQuery, GetMatchingCriteriaResponse>
{
    private readonly IMatchingCriteriaRepo _repo;

    public GetMatchingCriteriaHandler(IMatchingCriteriaRepo repo)
    {
        _repo = repo;
    }

    public async Task<GetMatchingCriteriaResponse> Handle(GetMatchingCriteriaQuery request, CancellationToken cancellationToken)
    {
        var criteria = await _repo.Get();

        return new GetMatchingCriteriaResponse
        {
            MatchingMethodId = criteria.MatchingMethodId,
            MatchingMethod = criteria.MatchingMethod,
            ReturnOnMatchRatio = criteria.ReturnOnMatchRatio
        };
    }
}