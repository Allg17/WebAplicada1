using FacturacionAplicada.DAL;
using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FacturacionAplicada.BLL
{
    public class EntradaArticuloBLL
    {
        public static bool Guardar(EntradaArticulo producto)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if (db.EntradaArticulo.Add(producto) != null)
                {
                    var articulo = ProductoBLL.Buscar(producto.ArticuloID);
                    articulo.Cantidad += producto.Cantidad; 
                    ProductoBLL.Modificar(articulo);
                    db.SaveChanges();
                    paso = true;

                    db.Dispose();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Contexto db = new Contexto();
                var producto = db.EntradaArticulo.Find(id);
                if (producto != null)
                {
                    var articulo = ProductoBLL.Buscar(producto.ArticuloID);
                    articulo.Cantidad -= producto.Cantidad;
                    ProductoBLL.Modificar(articulo);
                    db.Entry(producto).State = EntityState.Deleted;

                    if (db.SaveChanges() > 0)
                    {
                        paso = true;
                        db.Dispose();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(EntradaArticulo producto)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(producto).State = EntityState.Modified;
                var EntradaVieja = Buscar(producto.EntradaArticuloID);
                var articulo = ProductoBLL.Buscar(producto.ArticuloID);
                articulo.Cantidad -= EntradaVieja.Cantidad;
                articulo.Cantidad += producto.Cantidad;
                ProductoBLL.Modificar(articulo);

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                    db.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return paso;
        }

        public static EntradaArticulo Buscar(int id)
        {
            Contexto db = new Contexto();
            EntradaArticulo product = new EntradaArticulo();
            try
            {
                product = db.EntradaArticulo.Find(id);

                db.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }

        public static List<EntradaArticulo> GetList(Expression<Func<EntradaArticulo, bool>> product)
        {
            List<EntradaArticulo> list = new List<EntradaArticulo>();
            Contexto db = new Contexto();
            try
            {
                list = db.EntradaArticulo.Where(product).ToList();
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
    }
}
