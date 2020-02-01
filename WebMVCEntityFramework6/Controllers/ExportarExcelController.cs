using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;

namespace WebMVCEntityFramework6.Controllers
{
    public class ExportarExcelController : Controller
    {
        // GET: ExportarExcel
        public ActionResult ExportarExcel()
        {
            return View();
        }

        public void ExportarArchivoExcel()
        {
            DataTable dtExcel = new DataTable();
            string nombreArchivo = "HolaMundo.xlsx";
            List<Entidades.Factura.Factura> ListFactura = new List<Entidades.Factura.Factura>();

            try
            {

                Negocio.Factura.Factura negFactura = new Negocio.Factura.Factura();
                ListFactura = negFactura.GetFactura();


                dtExcel.Columns.Add("Id");
                dtExcel.Columns.Add("Nombre");
                dtExcel.Columns.Add("Descripcion");

                foreach(var fac in ListFactura)
                {
                    dtExcel.Rows.Add(fac.Id, fac.Concepto, fac.Monto);
                }


                var book = new ExcelQueryFactory("C:\\Users\\k697344\\Documents\\HolaMundo.xlsx");

                var rows = book.Worksheet("HolaMundo").ToList();

                //DataTable ds = ExcelLibrary.DataSetHelper.CreateDataTable("C:\\Users\\k697344\\Documents\\HolaMundo.xlsx", "HolaMundo");

                using (XLWorkbook wb = new XLWorkbook())
                {

                    

                    wb.Worksheets.Add(dtExcel, "HolaMundo");

                    var work = wb.Worksheet("HolaMundo");

                    work.Cells("A1:A3").Style.Fill.BackgroundColor = XLColor.Yellow;
                    work.Cell(17,1).Value = "Analisis";

                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreArchivo);

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }

                }

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}