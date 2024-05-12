using FluentValidation;

namespace Back.Personas.CasosDeUso.User.Crear.Validaciones
{
    public class CrearUsuarioValidacion : AbstractValidator<CrearUsuarioRequest>
    {
        public CrearUsuarioValidacion()
        {
            RuleFor(r => r.NombreUsuario).NotNull().WithMessage($"'NombreUsuario' no puede estar en vacío").NotEmpty().WithMessage("$'NombreUsuario' no puede ser null");
            RuleFor(r => r.Contrasena).NotNull().WithMessage("$'Contrasena' no puede ser null").NotEmpty().WithMessage($"'Contrasena' no puede estar en vacío");
        }
    }
}
