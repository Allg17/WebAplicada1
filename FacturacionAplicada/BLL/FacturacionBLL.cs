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
    public class FacturacionBLL
    {


        public static bool Guardar(Factura bill)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.bill.Add(bill) != null)
                {
                    db.SaveChanges();
                    db.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool GuardarDetalle(FacturaDetalle bill)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Billes.Add(bill) != null)
                {
                    db.SaveChanges();
                    db.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.bill.Find(Id);
                if (eliminar != null)
                {
                     
                    foreach (var item in GetList(x => x.FacturaId == Id).Last().BillDetalle)
                    {
                        db.product.Find(item.ProductoId).Cantidad += item.Cantidad;  
                    }
                    db.Billes.RemoveRange(db.Billes.Where(x => x.FacturaId == eliminar.FacturaId));
                    db.Entry(eliminar).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                    {
                        db.Dispose();
                        paso = true;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Modificar(Factura bill)
        {
            bool paso = false;
            bool paso1 = false;
            Contexto db = new Contexto();
            try
            {
                //Eliminar Detalle de la base de datos si no existe en la lista de el llenaClase
                var Eliminar = FacturaDetalleBLL.GetList(x => x.FacturaId == bill.FacturaId);
                if (bill.BillDetalle.Count < Eliminar.Count)
                    foreach (var itemsEliminar in Eliminar)
                    {
                        if (!bill.BillDetalle.Exists(x => x.Id.Equals(itemsEliminar.Id)))
                        {
                            HerramientasBLL.ArreglarProductoDetalle(itemsEliminar);
                            FacturaDetalleBLL.Eliminar(itemsEliminar.Id);
                        }
                    }

                var billes = Buscar(bill.FacturaId);
                db.Entry(bill).State = EntityState.Modified;
                BLL.HerramientasBLL.ArreglarProducto(billes);
                foreach (var item in bill.BillDetalle)
                {
                    if (item.Id == 0)
                    {
                        GuardarDetalle(item);
                    }
                    else
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            paso1 = true;
                            paso = true;
                        }
                    }


                }
                if (paso1 == false)
                {
                    if (db.SaveChanges() > 0)
                    {

                        paso = true;
                    }
                }
                BLL.HerramientasBLL.DescontarProductos(Buscar(bill.FacturaId).BillDetalle);

                db.Dispose();

            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static Factura Buscar(int id)
        {
            Factura bill = new Factura();
            Contexto db = new Contexto();
            try
            {

                bill = db.bill.Find(id);
                if (bill != null)
                {
                    bill.BillDetalle.Count();
                }

                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return bill;
        }

        public static List<Factura> GetList(Expression<Func<Factura, bool>> bill)
        {
            List<Factura> factura = new List<Factura>();
            Contexto db = new Contexto();
            try
            {
                factura = db.bill.Where(bill).ToList();
                foreach (var item in factura)
                {
                    item.BillDetalle.Count();
                }

                db.Dispose();


            }
            catch (Exception)
            {

                throw;
            }

            return factura;
        }



    }
}
