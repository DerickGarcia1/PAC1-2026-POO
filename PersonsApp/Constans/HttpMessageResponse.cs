using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsApp.Constans
{
    public class HttpMessageResponse
    {
        public const string REGISTER_NOT_FOUND = "Registro no encontrado";
        public const string INTERNAL_SERVER_ERROR = "Error Interno del Servidor";
        public const string REGISTER_FOUND = "Registro encontrado";
        public const string REGISTER_CREATED = "Registro creado exitosamente";
        public const string REGISTER_UPDATED = "Registro editado exitosamente";
        public const string REGISTER_DELETED = "Registro eliminado correctamente.";
        public const string REGISTERS_FOUND = "Registros encontrados.";
    }
}