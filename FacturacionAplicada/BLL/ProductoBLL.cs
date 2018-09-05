using FacturacionAplicada.DAL;
using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FacturacionAplicada.BLL
{
    public class ProductoBLL
    {

        public static bool Guardar(Producto producto)
        {
            bool paso = false;

            Contexto db = new Contexto();
            try
            {
                if(db.product.Add(producto)!=null)
                {
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
                var producto = db.product.Find(id);
                if(producto!=null)
                {
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

        public static bool Modificar(Producto producto)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(producto).State = EntityState.Modified;
                if(db.SaveChanges()>0)
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

        public static Producto Buscar(int id)
        {
            Contexto db = new Contexto();
            Producto product = new Producto();
            try
            {
                product = db.product.Find(id);
               
                db.Dispose();
 
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }

        public static List<Producto> GetList(Expression<Func<Producto,bool>>product)
        {
            List<Producto> list = new List<Producto>();
            Contexto db = new Contexto();
            try
            {
                list = db.product.Where(product).ToList();
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
