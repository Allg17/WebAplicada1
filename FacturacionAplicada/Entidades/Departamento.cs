using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FacturacionAplicada.Entidades
{
   public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }

        public Departamento(int idDepartamento, string nombre)
        {
            this.DepartamentoId = idDepartamento;
            this.Nombre = nombre;
        }

        public Departamento()
        {
            this.DepartamentoId = 0;
            this.Nombre = string.Empty;
        }
    }
}
