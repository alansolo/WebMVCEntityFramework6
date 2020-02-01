using Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Datos.Factura
{
    public class Factura
    {
        public string GuardarFactura(Entidades.Factura.Factura Factura, List<Entidades.Factura.DetalleFactura> ListDetalleFactura)
        {
            string resultado = "";

            try
            {
                using (var bd = new PruebaEntities())
                {

                    //var dos = bd.Factura;
                    using (var tran = new TransactionScope())
                    {
                        //dos.Add(Factura);
                        //var uno = bd.Factura;
                        //uno.Add(Factura);
                        bd.Factura.Add(Factura);
                        bd.SaveChanges();

                        ListDetalleFactura.ForEach(n =>
                        {
                            n.IdFactura = Factura.Id;
                            bd.DetalleFactura.Add(n);
                        });

                        bd.SaveChanges();

                        //tran.Dispose();

                        tran.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;

            }

            return resultado;
        }
    }
}
