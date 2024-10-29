namespace INFRASTRUCTURE.Commons.Bases.Request;

public class BasePaginationRequest
{ 
    public int NumPage { get; set; } = 1;
    public int NumRecordPage { get; set; } = 10;
    public readonly int NumMaxRecordsPage = 20;
    public string Order { get; set; } = "asc";
    public string? Sort { get; set; } = null;

    public int Records
    {
        get => NumRecordPage; 
        set
        {
            NumRecordPage = (value > NumMaxRecordsPage)? NumMaxRecordsPage : value;
        }
    }
}