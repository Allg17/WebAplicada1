using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FacturacionAplicada.Entidades
{
    [Serializable()]
    public class Producto
    {
        [Key]
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DepartamentoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public DateTime Fecha { get; set; }

        public Producto(int idproducto, string descripcion, decimal precio, int departamentoId, int cantidad, decimal costo, decimal ganancia, DateTime fecha)
        {
            Idproducto = idproducto;
            Descripcion = descripcion;
            Precio = precio;
            DepartamentoId = departamentoId;
            Cantidad = cantidad;
            Costo = costo;
            Ganancia = ganancia;
            Fecha = fecha;
        }

        public Producto()
        {
            this.Idproducto = 0;
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.DepartamentoId = 0;
            this.Cantidad = 0;
            this.Costo = 0;
            Ganancia = 0;
            Fecha = DateTime.Now;

        }
    }
}
