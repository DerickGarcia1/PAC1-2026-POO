
namespace PersonsApp.Dtos.Common
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }//Codigo de Respuesta HTTP
        public string Message { get; set; } //Mensaje de Respuesta
        public bool Status { get; set; } //Verdadero o Falso dependiendo del resultado de la operacion
        public T Data { get; set; } //Datos de Respuesta
    }
}