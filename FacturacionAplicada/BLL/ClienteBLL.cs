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
    public class ClienteBLL
    {
        public static bool Guardar(Cliente cliente)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.customer.Add(cliente) != null)
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
                var eliminar = db.customer.Find(Id);
                if(eliminar!=null)
                {
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

        public static bool Modificar(Cliente customer)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
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

        public static Cliente Buscar(int id)
        {
            Cliente customer = new Cliente();
            Contexto db = new Contexto();
            try
            {

                customer = db.customer.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }

        public static List<Cliente> GetList(Expression<Func<Cliente, bool>> user)
        {
            List<Cliente> customer = new List<Cliente>();
            Contexto db = new Contexto();
            try
            {
                customer = db.customer.Where(user).ToList();
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }



    }
}
