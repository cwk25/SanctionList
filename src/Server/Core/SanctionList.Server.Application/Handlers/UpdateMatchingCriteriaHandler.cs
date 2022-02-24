using MediatR;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.WatchlistConfig;
using SanctionList.Shared.Dto.Commands;

namespace SanctionList.Server.Application.Handlers;

public class UpdateMatchingCriteriaHandler :IRequestHandler<UpdateMatchingCriteriaCommand, Unit>
{
    private readonly IMatchingCriteriaRepo _repo;

    public UpdateMatchingCriteriaHandler(IMatchingCriteriaRepo repo)
    {
        _repo = repo;
    }

    public async Task<Unit> Handle(UpdateMatchingCriteriaCommand request, CancellationToken cancellationToken)
    {
        await _repo.Update(new MatchingCriteria
        {
            MatchingMethodId = request.MatchingMethodId,
            ReturnOnMatchRatio = request.ReturnOnMatchRatio
        });

        return Unit.Value;
    }
}