public class AuditLog
{
    public int Id {get; set;}
    public String Username {get; set;} = String.Empty;
    public String Role {get; set;} = String.Empty;
    public String Method{get; set;} = String.Empty;

    public String Endpoint {get; set;} = String.Empty;
    public int StatusCode {get; set;}
    public DateTime Timestamp {get; set;}
}