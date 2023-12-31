﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public static Modelo.Result AgregarProducto(Modelo.Producto Producto)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities context = new Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities())
                {
                    int query = context.Insertar(Producto.Nombre, Producto.Precio, Producto.Fabricante.codigo);
                    if (query > 0)
                    {
                        result.Correcto = true;
                    }
                    else
                    {
                        result.MensajeError = "No se pudo agregar correctamente el producto";
                        result.Correcto = false;
                    }
                }

            }
            catch (Exception Ex)
            {
                result.Correcto = false;
            }
            return result;
        }
        public static Modelo.Result ListaProducto()
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities context = new Conexion.DB_CeciliaGabriela_EscalonaChavarriaEntities())
                {
                    var query = context.ListaProducto();
                    if (query != null)
                    {
                        result.Objetos = new List<object>();

                        foreach (var obj in query)
                        {
                            Modelo.Producto Productos = new Modelo.Producto();
                            Productos.Codigo = obj.codigo;
                            Productos.Nombre = obj.nombre;
                            Productos.Precio = obj.precio.Value;
                            Productos.Fabricante = new Modelo.Fabricante();
                            Productos.Fabricante.nombre = obj.fabricante;

                            result.Objetos.Add(Productos);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return result;
        }
    }
}
