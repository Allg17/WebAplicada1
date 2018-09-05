using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FacturacionAplicada.Entidades
{
   
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string FormaDePago { get; set; }
        public decimal Devuelta { get; set; }
        public decimal EfectivoRecibido { get; set; }

        public virtual List<FacturaDetalle> BillDetalle { get; set; }

        public Factura(int idFactura, decimal monto, int usuarioId, int clienteId, DateTime fecha, string descripcion, string formaDePago, decimal devuelta, decimal efectivoRecibido, List<FacturaDetalle> billDetalle)
        {
            this.FacturaId = idFactura;
            this.Monto = monto;
            this.UsuarioId = usuarioId;
            this.ClienteId = clienteId;
            this.Fecha = fecha;
            this.Descripcion = descripcion;
            this.FormaDePago = formaDePago;
            this.Devuelta = devuelta;
            this.EfectivoRecibido = efectivoRecibido;
            this.BillDetalle = billDetalle;
        }

        public Factura()
        {
            this.FacturaId = 0;
            this.Monto = 0;
            this.UsuarioId = 0;
            this.ClienteId = 0;
            this.Fecha = DateTime.Now;
            this.Descripcion = string.Empty;
            this.FormaDePago = string.Empty;
            this.Devuelta = 0;
            this.EfectivoRecibido = 0;
            BillDetalle = new List<FacturaDetalle>();
        }
    }
}
