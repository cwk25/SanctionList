namespace SanctionList.Shared.Dto.Responses;

public class GetMatchingCriteriaResponse
{
    public int MatchingMethodId { get; set; }
    public string MatchingMethod { get; set; }
    public int ReturnOnMatchRatio { get; set; }
}