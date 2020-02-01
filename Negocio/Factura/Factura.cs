using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Factura
{
    public class Factura
    {
        public string GuardarFactura(Entidades.Factura.Factura Factura, List<Entidades.Factura.DetalleFactura> ListDetalleFactura)
        {
            string resultado = "";

            try
            {
                Datos.Factura.Factura bdFactura = new Datos.Factura.Factura();

                resultado = bdFactura.GuardarFactura(Factura, ListDetalleFactura);
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
            }

            return resultado;
        }
    }
}
