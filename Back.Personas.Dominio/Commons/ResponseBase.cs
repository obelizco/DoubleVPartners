using System.Net;

namespace Back.Personas.Dominio.Commons
{
    public class ResponseBase<TEntity>
    {
        private HttpStatusCode code;
        private string errors;

        public ResponseBase(HttpStatusCode code, string errors)
        {
            this.code = code;
            this.errors = errors;
        }

        public ResponseBase(HttpStatusCode code = HttpStatusCode.OK, string message = "", TEntity data = default,
            List<Error> errors = null)
        {
            Code = (int)code;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public int Code { set; get; }
        public string Message { set; get; }
        public TEntity Data { set; get; }
        public List<Error> Errors { set; get; }
    }

    public class Error
    {
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
    }
}
