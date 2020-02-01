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

        public List<Entidades.Factura.Factura> GetFactura()
        {
            List<Entidades.Factura.Factura> ListFactura = new List<Entidades.Factura.Factura>();

            try
            {
                Datos.Factura.Factura bdFactura = new Datos.Factura.Factura();

                ListFactura = bdFactura.GetFactura();
            }
            catch (Exception ex)
            {
                
            }


            return ListFactura;
        }
    }
}
