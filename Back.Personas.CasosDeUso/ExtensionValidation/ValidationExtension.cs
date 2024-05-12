using Back.Personas.Dominio.Commons;
using FluentValidation.Results;

namespace Back.Personas.CasosDeUso.People.ExtensionValidation
{
    public static class ValidationExtension
    {
        public static List<Error> ResultErrors(this ValidationResult result)
        {
            return result.Errors.Select(s => new Error()
            {
                Codigo = s.ErrorCode,
                Detalle = s.PropertyName,
                Mensaje = s.ErrorMessage
            }
            ).ToList();
        }
    }
}
