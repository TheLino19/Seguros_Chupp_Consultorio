using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using AutoMapper;
using DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Mappers
{
    public class SeguroMappingsProfile : Profile
    {
        public SeguroMappingsProfile()
        {
            
            // Mapeo existente de SeguroRequestDto a SgrSeguro
            CreateMap<SeguroRequestDto, SgrSeguro>()
                .ForMember(dest => dest.IdEstado, opt => opt.MapFrom(src => src.IdEstado ?? 1))
                .ForMember(dest => dest.IdTipoSeguro, opt => opt.MapFrom(src => src.IdEstado ?? 1))
                .ForMember(dest => dest.IdSeguro, opt => opt.Ignore())
                .ForMember(dest => dest.AsgAsegurados, opt => opt.Ignore())
                .ForMember(dest => dest.IdEstadoNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdTipoSeguroNavigation, opt => opt.Ignore());

            // Nuevo mapeo de SgrSeguro a SeguroResponseDto
            CreateMap<SgrSeguro, SeguroResponseDto>()
                .ForMember(dest => dest.IdSeguro, opt => opt.MapFrom(src => src.IdSeguro))
                .ForMember(dest => dest.CodigoSeguro, opt => opt.MapFrom(src => src.CodigoSeguro))
                .ForMember(dest => dest.SumaAsegurada, opt => opt.MapFrom(src => src.SumaAsegurada))
                .ForMember(dest => dest.Prima, opt => opt.MapFrom(src => src.Prima))
                .ForMember(dest => dest.RangoEdadMin, opt => opt.MapFrom(src => src.RangoEdadMin))
                .ForMember(dest => dest.RangoEdadMax, opt => opt.MapFrom(src => src.RangoEdadMax))
                .ForMember(dest => dest.EsFamiliar, opt => opt.MapFrom(src => src.EsFamiliar))
                .ForMember(dest => dest.LimiteAsegurados, opt => opt.MapFrom(src => src.LimiteAsegurados))
                .ForMember(dest => dest.IdTipoSeguro, opt => opt.MapFrom(src => GetTipoSeguro(src.IdTipoSeguro)));


            CreateMap<SgrSeguro, SeguroCardDtocs>()
            .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => GetTipoSeguro(src.IdTipoSeguro)))
            .ForMember(dest => dest.limite, opt => opt.MapFrom(src => src.LimiteAsegurados))
            .ReverseMap();
        }

        private static string GetTipoSeguro(int tipo)
        {
            var tipoSeguro = "";
            switch (tipo)
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
}
