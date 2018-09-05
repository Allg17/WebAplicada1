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
    public class DepartamentoBLL
    {
        public static bool Guardar(Departamento departamento)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Depart.Add(departamento) != null)
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

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Depart.Find(Id);
                if(eliminar!=null)
                {
                    db.Entry(eliminar).State = EntityState.Deleted;
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

        public static bool Modificar(Departamento departamento)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(departamento).State = EntityState.Modified;
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

        public static Departamento Buscar(int id)
        {
            Departamento departamento = new Departamento();
            Contexto db = new Contexto();
            try
            {
                departamento = db.Depart.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return departamento;
        }

        public static List<Departamento> GetList(Expression<Func<Departamento, bool>> user)
        {
            List<Departamento> usuario = new List<Departamento>();
            Contexto db = new Contexto();
            try
            {
                usuario = db.Depart.Where(user).ToList();
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }
    }
}
