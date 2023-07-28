using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Result
    {
        public bool Correcto { get; set; }
        public string MensajeError { get; set; }
        public List<object> Objetos { get; set; }
        public object Objeto { get; set; }
        public Exception Ex { get; set; }
    }
}
