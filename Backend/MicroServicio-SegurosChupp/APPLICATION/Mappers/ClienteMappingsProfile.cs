using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using AutoMapper;
using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Response;

namespace APPLICATION.Mappers;

public class ClienteMappingsProfile : Profile
{
    public ClienteMappingsProfile()
    {
        CreateMap<ClienteRequestDto, AsgCliente>()
            .ForMember(dest => dest.IdEstado, opt => opt.Ignore()) // Valor predeterminado de IdEstado
            .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.FechaNacimiento))
            .ForMember(dest => dest.IdCliente, opt => opt.Ignore()) // Ignorar Id generado por la DB
            .ForMember(dest => dest.AsgAsegurados, opt => opt.Ignore()) // Ignorar colección de AsgAsegurados
            .ForMember(dest => dest.IdEstadoNavigation, opt => opt.Ignore()); // Ignorar navegación de IdEstado

        CreateMap<AsgCliente, ClienteResponseDto>()
           .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.IdEstado == 1))
           .ForMember(dest => dest.edad, opt => opt.MapFrom(src => CalculateAge(src.FechaNacimiento)));


        CreateMap < SgrSeguro, SeguroAsociadoDTO>()
            .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.CodigoSeguro))
            .ForMember(dest => dest.TipoSeguro, opt => opt.MapFrom(src => GetTipoSeguro(src.IdTipoSeguro)))
            .ReverseMap();

        CreateMap<SgrSeguro, SeguroCardDtocs>()
           .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => GetTipoSeguro(src.IdTipoSeguro)))
           .ForMember(dest => dest.limite, opt => opt.MapFrom(src => src.LimiteAsegurados))
           .ReverseMap();
    }
    private int CalculateAge(DateOnly fechaNacimiento)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - fechaNacimiento.Year;
        if (today.Month < fechaNacimiento.Month || (today.Month == fechaNacimiento.Month && today.Day < fechaNacimiento.Day))
            age--;
        return age;
    }

    private static string GetTipoSeguro(int tipo)
    {
        var tipoSeguro = "";
        switch(tipo)
        {
            case 1:
                tipoSeguro = "Familiar";
                 break;
            case 2:
                tipoSeguro = "Viaje";
                break;
            case 3:
                tipoSeguro = "Vehiculo";
                break;
        }

        return tipoSeguro;
    }
}

