namespace SanctionList.Shared.Dto.Responses;

public class BlacklistedCustomerResponse
{
    public string DowJonesId { get; set; }
    public string IdNo { get; set; }
    public string IdType { get; set; }
    public char Gender { get; set; }
    public DateTime Dob { get; set; }
    public string IndOrg { get; set; }
    public bool HasSanction { get; set; }
    public bool HasOccupation { get; set; }
    public bool HasRelationship { get; set; }
    public bool HasOtherList { get; set; }
    public bool IsActive { get; set; }
    public string Citizenship { get; set; }
    public List<BlacklistedMatch> MatchedNames { get; set; }
}