namespace INFRASTRUCTURE.Commons.Bases.Response;

public class BaseEntityResponse<T>
{
    public int? TotalRecords { get; set; }
    public List<T> items { get; set; }
}