using MediatR;
using SanctionList.Shared.Dto.Responses;

namespace SanctionList.Shared.Dto.Queries;

public class GetBlacklistedCustomerQuery : IRequest<IEnumerable<BlacklistedCustomerResponse>>
{
    public string Name { get; set; }
}