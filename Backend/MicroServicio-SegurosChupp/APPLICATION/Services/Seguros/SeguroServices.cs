using APPLICATION.Commons.Bases;
using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using APPLICATION.Validators;
using AutoMapper;
using DOMAIN.Entities;
using INFRASTRUCTURE.Commons.Bases.Request;
using INFRASTRUCTURE.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Services.Seguros
{
    public class SeguroServices : ISeguroServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SeguroValidator _validations;

        public SeguroServices(IUnitOfWork unitOfWor, IMapper mapper, SeguroValidator validations)
        {
            _unitOfWork = unitOfWor;
            _mapper = mapper;
            _validations = validations;

        }
        public async Task<BaseResponse<bool>> EliminarSeguro(string codigo)
        {
            var response = new BaseResponse<bool>();

            try
            {
                if (!string.IsNullOrEmpty(codigo))
                {
                    response.IsSuccess = await _unitOfWork.Seguros.EliminarSeguro(codigo);
                    response.Message = response.IsSuccess ? "Seguro eliminado exitosamente." : "No se encontró el seguro.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "El codigo no puede estar vacía.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error al intentar eliminar el seguro.";
            }

            return response;
        }

        public async Task<BaseResponse<List<SeguroResponseDto>>> ListarSeguro(BaseFiltersRequest filter)
        {
            var response = new BaseResponse<List<SeguroResponseDto>>();

            try
            {
                if (filter == null)
                {
                    response.Message = "Filtro inválido";
                    return response;
                }

                var seguros = await _unitOfWork.Seguros.ListarSeguros(filter);

                response.IsSuccess = seguros != null;
                response.Data = _mapper.Map<List<SeguroResponseDto>>(seguros.items);
                response.Message = response.IsSuccess ? "Consulta exitosa" : "No se encontraron registros";

                return response;
            }
            
            
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error al listar los codigos";

                return response;
            }
        }

        public async Task<BaseResponse<List<SeguroResponseDto>>> ListarSeguroCard(BaseFiltersRequest filter)
        {
            var response = new BaseResponse<List<SeguroResponseDto>>();

            try
            {
                if (filter == null)
                {
                    response.Message = "Filtro inválido";
                    return response;
                }

                var seguros = await _unitOfWork.Seguros.ListarSeguros(filter);

                response.IsSuccess = seguros != null;
                //response.Data = _mapper.Map<List<SeguroCardDtocs>>(seguros.items);
                response.Message = response.IsSuccess ? "Consulta exitosa" : "No se encontraron registros";

                return response;
            }


            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error al listar los codigos";

                return response;
            }
        }

        public async Task<BaseResponse<bool>> ModificarSeguro(SeguroRequestDto request)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validations.ValidateAsync(request);
            try
            {
                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = "Llenar todos los campos correctamente";
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var seguro = _mapper.Map<SgrSeguro>(request);
                var result = await _unitOfWork.Seguros.ModificarSeguro(seguro);
                if (result)
                {
                    response.IsSuccess = true;
                    response.Message = "se modifico correctamente";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "ocurrio un error al modificar";
                }

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "ocurrio un error con el servidor";
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterSeguro(SeguroRequestDto request)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validations.ValidateAsync(request);
            try
            {
                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = "Llenar todos los campos correctamente";
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var cliente = _mapper.Map<SgrSeguro>(request);
                response.Data = await _unitOfWork.Seguros.RegisterSeguro(cliente);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "se guardo correctamente";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "El codigo del Seguro ya se encuentra en uso";
                }

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = "ocurrio un error con el servidor";
            }
            return response;
        }
    }
}
