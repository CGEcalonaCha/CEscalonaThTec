using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Modelo
{
    public class Producto
    {
        public int codigo { get; set; }
        //[Required(ErrorMessage = "Campo Obligatorio")]
        //[RegularExpression("(^[a-zA-Z ]*$)", ErrorMessage = "Solo se permiten letras Nombre")]
        public string nombre { get; set; }
        //[Required(ErrorMessage = "Campo Obligatorio")]
        //[RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números en numeros ")]
        public decimal precio { get; set; }
        public Fabricante fabricante { get; set; }
        public List<object> productos { get; set; }
    }
}
