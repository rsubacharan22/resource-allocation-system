public class ResourceDemand
{
    public int Id {get;set;}
    public int ProjectId {get;set;}
    public String Role {get;set;} = String.Empty;
    public int RequiredCount {get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}
    public Project? Project { get; set; }
}