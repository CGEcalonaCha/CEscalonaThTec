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
            Modelo.Producto Producto = new Modelo.Producto();


            Producto.productos = result.Objetos;

            return View(Producto);
        }
        [HttpGet]
        public ActionResult Agregar(int? idProductos)
        {
            Modelo.Producto cine = new Modelo.Producto();
            Modelo.Result result = new Modelo.Result();
            cine.fabricante = new Modelo.Fabricante();
            cine.fabricante.fabricantes = new List<object>();
            result = Negocio.Fabricante.Listafabricante();
            if (result.Correcto)
            {

                cine.fabricante.fabricantes = result.Objetos;
            }
            if (idProductos == null)
            {

                return View(cine);
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
            if (producto.codigo == 0)
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