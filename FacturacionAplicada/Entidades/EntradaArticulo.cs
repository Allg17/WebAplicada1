using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionAplicada.Entidades
{
    [Serializable()]
    public class EntradaArticulo
    {
        [Key]
        public int EntradaArticuloID { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int ArticuloID { get; set; }

        public EntradaArticulo()
        {
            EntradaArticuloID = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
            ArticuloID = 0;
        }

        public EntradaArticulo(DateTime fecha_e, int cantidad_e, int articuloid_e)
        {
            EntradaArticuloID = 0;
            Fecha = fecha_e;
            Cantidad = cantidad_e;
            ArticuloID = articuloid_e;
        }
    }
}