using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult ListaProducto()
        {

            Modelo.Result result = Negocio.Producto.ListaProducto();
            Modelo.Producto producto = new Modelo.Producto();

            producto.Total = result.Objetos.Count;
            producto.Productos = result.Objetos;

            return View(producto);
        }
        [HttpGet]
        public ActionResult Agregar(int? idProductos)
        {
            Modelo.Producto producto = new Modelo.Producto();
            producto.Fabricante = new Modelo.Fabricante();
            producto.Fabricante.fabricantes = new List<object>();
            Modelo.Result result = Negocio.Fabricante.Listafabricante();
            
            if (result.Correcto)
            {

                producto.Fabricante.fabricantes = result.Objetos;
            }
            if (idProductos == null)
            {

                return View(producto);
            }
            else
            {

            }
            return View("Modal");
        }

        [HttpPost]
        public ActionResult Agregar(Modelo.Producto producto)
        {
            Modelo.Result result = new Modelo.Result();
            if (producto.Codigo == 0)
            {
                result = Negocio.Producto.AgregarProducto(producto);
                if (result.Correcto)
                {
                    ViewBag.Message = "El producto Se Agrego Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio Un Error Al Agregar El Producto" + result.MensajeError;
                }
            }
            else
            {

            }
            return View("Modal");
        }
     
    }
}