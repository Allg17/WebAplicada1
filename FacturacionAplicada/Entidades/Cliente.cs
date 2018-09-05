using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FacturacionAplicada.Entidades
{
    public class Cliente
    {

        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente(int idCliente, string nombre, string direccion, string cedula, string telefono, DateTime fecha)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Direccion = direccion;
            Cedula = cedula;
            Telefono = telefono;
            Fecha = fecha;
        }

        public Cliente()
        {
            this.IdCliente = 0;
            this.Nombre = string.Empty;
            this.Direccion = string.Empty;
            this.Cedula = string.Empty;
            this.Telefono = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
