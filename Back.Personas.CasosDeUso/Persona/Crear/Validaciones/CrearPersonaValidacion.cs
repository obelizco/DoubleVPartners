using Back.Personas.CasosDeUso.People.Nuevo;
using FluentValidation;

namespace Back.Personas.CasosDeUso.People.Nuevo.Validaciones
{
    public class CrearPersonaValidacion : AbstractValidator<CrearPersonaRequest>
    {
        public CrearPersonaValidacion()
        {
            RuleFor(r => r.Nombres).NotNull().WithMessage($"'Nombres' no puede estar en vacío").NotEmpty().WithMessage("$'Nombres' no puede ser null");
            RuleFor(r => r.Apellidos).NotNull().WithMessage("$'Apellidos' no puede ser null").NotEmpty().WithMessage($"'Apellidos' no puede estar en vacío");
            RuleFor(r => r.Identificacion).NotNull().WithMessage($"'Identificacion' no puede ser null").NotEmpty().WithMessage($"'Identificacion' no puede estar en vacío");
            RuleFor(r => r.Email).NotNull().WithMessage($"'Email' no puede ser null").NotEmpty().WithMessage($"'Email' no puede estar en vacío");
            RuleFor(r => r.TipoIdentificacion).NotNull().WithMessage($"'TipoIdentificacion' no puede ser null").NotEmpty().WithMessage($"'TipoIdentificacion' no puede estar en vacío");
        }

    }
}
