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
    public class UsuarioBLL
    {
        public static bool Guardar(Usuario use)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.user.Add(use) != null)
                {
                    db.SaveChanges();
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
                var eliminar = db.user.Find(Id);
                if(eliminar!=null)
                {
                    db.Entry(eliminar).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                    {
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

        public static bool Modificar(Usuario use)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(use).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static Usuario Buscar(int id)
        {
            Usuario usuario = new Usuario();
            Contexto db = new Contexto();
            try
            {
                usuario = db.user.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> user)
        {
            List<Usuario> usuario = new List<Usuario>();
            Contexto db = new Contexto();
            try
            {
                usuario = db.user.Where(user).ToList();
              
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

       
    }
}
