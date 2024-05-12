using AutoMapper;
using Back.Personas.CasosDeUso.People.Nuevo;
using Back.Personas.CasosDeUso.User.Crear;
using Back.Personas.Dominio.Dtos;
using Back.Personas.Dominio.Entities;

namespace Back.Personas.CasosDeUso.Service.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            CreateMap<Persona, CrearPersonaRequest>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, CrearUsuarioRequest>().ReverseMap();
        }

    }
}
