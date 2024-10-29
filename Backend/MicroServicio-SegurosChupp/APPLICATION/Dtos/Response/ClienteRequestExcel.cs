namespace APPLICATION.Dtos.Response;

public class ClienteRequestExcel
{
    public string Cedula { get; set; }
    public string Nombres { get; set; }
    public string Telefono { get; set; }
    public int Edad { get; set; }

    public ClienteRequestExcel(Dictionary<string, object> request)
    {
        Cedula = request["cedula"].ToString();
        Nombres = request["nombres"].ToString();
        Telefono = request["telefono"].ToString();
        Edad = Convert.ToInt32(request["edad"]);

    }

    public ClienteRequestExcel(string cedula, string nombres, string telefono, int edad)
    {
        Cedula = cedula;
        Nombres = nombres;
        Telefono = telefono;
        Edad = edad;
    }
    public ClienteRequestExcel() { }
}