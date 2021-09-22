using System.Collections.Generic;

namespace Domain.Common
{
    public class ResponseData
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public IEnumerable<object> Datos { get; set; }
    }
}
