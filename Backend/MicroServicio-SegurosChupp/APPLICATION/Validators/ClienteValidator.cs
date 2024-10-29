using APPLICATION.Dtos.Request;
using APPLICATION.Dtos.Response;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;

namespace APPLICATION.Validators;

public class ClienteValidator : AbstractValidator<ClienteRequestDto>
{
    public ClienteValidator()
    {
        RuleFor(x => x.Cedula)
            .NotNull().WithMessage("Este campo es obligatorio")
            .NotEmpty().WithMessage("No se ha detectado ninguna cedula");
        RuleFor(x => x.Nombres)
            .NotNull().WithMessage("Este campo es obligatorio")
            .NotEmpty().WithMessage("Se ha enviado vacio el campo nombre");
        RuleFor(x => x.FechaNacimiento)
            .NotNull().WithMessage("Este campo es obligatorio")
            .NotEmpty().WithMessage("No se ha ingresado fecha de Nacimiento");
        RuleFor(x => x.Telefono)
            .NotNull().WithMessage("Este campo es obligatorio")
            .NotEmpty().WithMessage("Se ha enviado vacio el campo telefono");

    }
}