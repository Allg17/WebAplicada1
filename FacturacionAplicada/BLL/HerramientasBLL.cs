using FacturacionAplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAplicada.BLL
{
    public class HerramientasBLL
    {
        public static Usuario user = new Usuario();
        public static bool Login = false;
        public static decimal CalcularGanancia(decimal precio, decimal costo)
        {
            return precio - costo;
        }

        public static decimal devuelta(decimal monto, decimal efectivo)
        {
            decimal devuelta = 0;

            devuelta = efectivo - monto;
            return devuelta;
        }

        public static decimal CalcularMonto(decimal importe)
        {
            decimal monto = 0;
            monto += importe;

            return monto;
        }

        public static decimal Importe(decimal cantidadDefecto, decimal cantidad, decimal precio, int id, int ID)
        {
            decimal importe = 0;
            if (ID == id)
            {

                importe = cantidad * precio;
            }
            else
            {
                importe = cantidadDefecto * precio;
            }


            return importe;
        }

        public static decimal Importedemas(decimal cantidad, decimal precio)
        {
            decimal importe = 0;


            importe = cantidad * precio;



            return importe;
        }

        public static void DescontarProductos(List<FacturaDetalle> bill)
        {
            // Descontar cantidad a productos


            foreach (var item in bill)
            {
                var producto = BLL.ProductoBLL.Buscar(item.ProductoId);


                producto.Cantidad -= item.Cantidad;

                BLL.ProductoBLL.Modificar(producto);

            }

        }

        public static void DescontarBuscando(List<FacturaDetalle> facturaDetalles, int id)
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();
            detalle = FacturaDetalleBLL.GetList(x => x.FacturaId == id);
            foreach (var item in detalle)
            {
                foreach (var items in facturaDetalles)
                {
                    if (item.ProductoId == items.ProductoId)
                        if (item.Cantidad != items.Cantidad)
                        {
                            DescontarProducto(items, item);
                        }
                }
            }
        }

        public static void DescontarProducto(FacturaDetalle item, FacturaDetalle ite)
        {
            var producto = ProductoBLL.Buscar(item.ProductoId);
            producto.Cantidad += ite.Cantidad;
            producto.Cantidad -= item.Cantidad;
            ProductoBLL.Modificar(producto);


        }

        public static void ArreglarProducto(Factura bill)
        {
            foreach (var item in bill.BillDetalle)
            {
                var producto = BLL.ProductoBLL.Buscar(item.ProductoId);

                producto.Cantidad += item.Cantidad;

                BLL.ProductoBLL.Modificar(producto);

            }
        }

        public static void ArreglarProductoDetalle(FacturaDetalle bill)
        {

            var producto = BLL.ProductoBLL.Buscar(bill.ProductoId);
            producto.Cantidad += bill.Cantidad;
            BLL.ProductoBLL.Modificar(producto);



        }

        public static List<FacturaDetalle> Editar(List<FacturaDetalle> list, FacturaDetalle factura)
        {
            foreach (var item in list)
            {
                if (item.Id == factura.Id)
                {
                    item.Cantidad = factura.Cantidad;
                }

            }

            return list;
        }

        public static decimal DescontarImporte(List<FacturaDetalle> list, int id)
        {
            decimal monto = 0;

            foreach (var item in list)
            {
                if (item.Id == id)
                {
                    item.Importe = item.Cantidad * item.Precio;
                    monto = item.Importe;
                }

            }



            return monto;
        }

        public static decimal RecalcularImporte(List<FacturaDetalle> list, int row)
        {
            decimal monto = 0;
            FacturaDetalle factura = list.ElementAt(row);
            factura.Importe = factura.Cantidad * factura.Precio;
            monto = factura.Importe;
            return monto;
        }

        public static decimal CalcularDevuelta(decimal efectivo, decimal monto)
        {
            decimal devuelta = 0;

            devuelta = efectivo - monto;
            return devuelta;
        }

        public static int Mayor(List<Factura> bill)
        {
            int mayor = 0;
            foreach (var item in bill)
            {
                if (mayor == 0)
                {
                    mayor = item.FacturaId;
                }
                else
                {
                    if (mayor < item.FacturaId)
                    {
                        mayor = item.FacturaId;
                    }
                }

            }

            return mayor;
        }

        public static decimal RetornarDevuelta(decimal efectivo, decimal monto)
        {
            decimal devuelta = CalcularDevuelta(efectivo, monto);

            return devuelta;
        }
    }
}