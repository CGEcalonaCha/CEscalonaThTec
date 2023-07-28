using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Fabricante
    {
        public static Modelo.Result Listafabricante()
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities context = new Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities())
                {
                    var query = context.ListaFabricante();
                    if (query != null)
                    {
                        result.Objetos = new List<object>();
                        
                        foreach (var obj in query)
                        {
                            Modelo.Fabricante fabricante = new Modelo.Fabricante();
                            fabricante.codigo = obj.codigo;
                            fabricante.nombre = obj.nombre;
                            result.Objetos.Add(fabricante);
                            result.Correcto = true;
                        }
                    }
                    else
                    {
                        result.Correcto = false;
                        result.MensajeError = "No se pudo realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correcto = false;
                result.MensajeError = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
