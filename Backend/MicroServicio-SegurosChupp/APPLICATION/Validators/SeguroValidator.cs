using APPLICATION.Dtos.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Validators
{
    public class SeguroValidator: AbstractValidator<SeguroRequestDto>
    {
        public SeguroValidator()
        {
            RuleFor(x => x.CodigoSeguro)
                .NotNull().WithMessage("Este campo es obligatorio")
                .NotEmpty().WithMessage("No se ha detectado ninguna codigo");
            RuleFor(x => x.SumaAsegurada)
                .NotNull().WithMessage("Este campo es obligatorio")
                .NotEmpty().WithMessage("Se ha enviado vacio el campo suma");
            RuleFor(x => x.Prima)
                .NotNull().WithMessage("Este campo es obligatorio")
                .NotEmpty().WithMessage("No se ha ingresado Prima");
            RuleFor(x => x.RangoEdadMax)
                .NotNull().WithMessage("Este campo es obligatorio")
                .NotEmpty().WithMessage("Se ha enviado vacio el campo Rango Edad MAX");
            RuleFor(x => x.RangoEdadMin)
                .NotNull().WithMessage("Este campo es obligatorio")
                .NotEmpty().WithMessage("Se ha enviado vacio el campo Rango Edad MIN");

        }
    }
}
