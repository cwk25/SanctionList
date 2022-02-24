using MediatR;
using SanctionList.Server.Application.Contracts;
using SanctionList.Shared.Dto.Queries;
using SanctionList.Shared.Dto.Responses;

namespace SanctionList.Server.Application.Handlers;

public class GetAllMatchingMethodHandler : IRequestHandler<GetAllMatchingMethodQuery, IEnumerable<MatchingMethodResponse>>
{
    private readonly IMatchingMethodRepo _repo;

    public GetAllMatchingMethodHandler(IMatchingMethodRepo repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<MatchingMethodResponse>> Handle(GetAllMatchingMethodQuery request, CancellationToken cancellationToken)
    {
        var methods = await _repo.Get();

        return methods.Select(m => new MatchingMethodResponse { Id = m.Id, Method = m.Method });
    }
}