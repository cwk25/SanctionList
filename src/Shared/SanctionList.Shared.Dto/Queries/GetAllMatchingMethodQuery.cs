using MediatR;
using SanctionList.Shared.Dto.Responses;

namespace SanctionList.Shared.Dto.Queries;

public class GetAllMatchingMethodQuery : IRequest<IEnumerable<MatchingMethodResponse>>
{
    
}