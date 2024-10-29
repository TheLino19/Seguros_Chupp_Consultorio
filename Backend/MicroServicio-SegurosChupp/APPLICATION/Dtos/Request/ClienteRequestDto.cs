using System;

namespace APPLICATION.Dtos.Request;

public class ClienteRequestDto
{
    public string Cedula { get; set; } 

    public string Nombres { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }


}