using MediatR;

namespace SanctionList.Shared.Dto.Commands;

public class UpdateMatchingCriteriaCommand : IRequest<Unit>
{
    public int MatchingMethodId { get; set; }
    public int ReturnOnMatchRatio { get; set; }
}