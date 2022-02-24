namespace SanctionList.Server.Domain.WatchlistConfig;

public class MatchingCriteria
{
    public int MatchingMethodId { get; set; }
    public string MatchingMethod { get; set; }
    public int ReturnOnMatchRatio { get; set; }
}