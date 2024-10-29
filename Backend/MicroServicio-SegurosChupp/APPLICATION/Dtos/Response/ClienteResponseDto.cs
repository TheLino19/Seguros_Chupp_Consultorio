namespace APPLICATION.Dtos.Response;

public class ClienteResponseDto
{
    public string cedula { set; get; }
    public string nombres { set; get; }
    public int edad { set; get; } =  10;
    public string estado { get; set; }
    
}