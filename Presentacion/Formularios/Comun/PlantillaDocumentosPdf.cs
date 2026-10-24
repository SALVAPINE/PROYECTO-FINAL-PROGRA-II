using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using Entidad;

namespace SistemaPublicidad.Formularios
{
    internal static class PlantillaDocumentosPdf
    {
        const string NombreEmpresa = "Sistema de Publicidad Multisucursal";
        static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-GT");

        public static Document CrearDocumento(string titulo)
        {
            var documento = new Document();
            documento.Info.Title = titulo;
            documento.Info.Author = NombreEmpresa;
            documento.Styles[StyleNames.Normal].Font.Name = "Arial";
            documento.Styles[StyleNames.Normal].Font.Size = 10.5;
            documento.Styles[StyleNames.Normal].Font.Color = Colors.Black;
            return documento;
        }

        public static void ConfigurarPaginaCarta(Section seccion)
        {
            seccion.PageSetup.PageFormat = PageFormat.Letter;
            seccion.PageSetup.TopMargin = Unit.FromCentimeter(1.7);
            seccion.PageSetup.BottomMargin = Unit.FromCentimeter(5.4);
            seccion.PageSetup.LeftMargin = Unit.FromCentimeter(1.8);
            seccion.PageSetup.RightMargin = Unit.FromCentimeter(1.8);
            seccion.PageSetup.FooterDistance = Unit.FromCentimeter(1.0);
        }

        public static string AgregarEncabezado(Section seccion)
        {
            string rutaLogo = CrearLogoTemporal();
            var encabezado = seccion.AddTable();
            encabezado.Borders.Width = 0;
            encabezado.AddColumn(Unit.FromCentimeter(1.8));
            encabezado.AddColumn(Unit.FromCentimeter(16.1));
            Row fila = encabezado.AddRow();
            fila.VerticalAlignment = VerticalAlignment.Center;
            Image logo = fila.Cells[0].AddImage(rutaLogo);
            logo.LockAspectRatio = true;
            logo.Width = Unit.FromCentimeter(1.5);
            Paragraph empresa = fila.Cells[1].AddParagraph(NombreEmpresa);
            empresa.Format.Font.Size = 11;
            empresa.Format.Font.Bold = true;
            empresa.Format.Font.Color = Colors.DarkBlue;
            empresa.Format.SpaceAfter = Unit.FromPoint(12);
            return rutaLogo;
        }

        public static void AgregarTitulo(Section seccion, string titulo)
        {
            Paragraph parrafo = seccion.AddParagraph(titulo);
            parrafo.Format.Font.Size = 20;
            parrafo.Format.Font.Bold = true;
            parrafo.Format.Font.Color = Colors.DarkBlue;
            parrafo.Format.SpaceAfter = Unit.FromPoint(4);
        }

        public static void AgregarIdentidadProducto(Section seccion, string nombre, string codigo)
        {
            Paragraph producto = seccion.AddParagraph(nombre ?? string.Empty);
            producto.Format.Font.Size = 14;
            producto.Format.Font.Bold = true;
            producto.Format.Font.Color = Colors.Black;
            producto.Format.SpaceAfter = Unit.FromPoint(2);

            Paragraph identificador = seccion.AddParagraph("Código: " + codigo);
            identificador.Format.Font.Size = 9;
            identificador.Format.Font.Color = Colors.Gray;
            identificador.Format.SpaceAfter = Unit.FromPoint(2);
        }

        public static void AgregarIdentidadDocumento(Section seccion, string identificador)
        {
            Paragraph parrafo = seccion.AddParagraph(identificador ?? string.Empty);
            parrafo.Format.Font.Size = 12;
            parrafo.Format.Font.Color = Colors.Gray;
            parrafo.Format.SpaceAfter = Unit.FromPoint(8);
        }

        public static void AgregarSeccion(Section seccion, string titulo,
            params KeyValuePair<string, string>[] campos)
        {
            KeyValuePair<string, string>[] disponibles = campos
                .Where(campo => !string.IsNullOrWhiteSpace(campo.Value)).ToArray();
            if (disponibles.Length == 0) return;

            Paragraph encabezado = seccion.AddParagraph(titulo);
            encabezado.Format.Font.Size = 11;
            encabezado.Format.Font.Bold = true;
            encabezado.Format.Font.Color = Colors.DarkBlue;
            encabezado.Format.SpaceBefore = Unit.FromPoint(10);
            encabezado.Format.SpaceAfter = Unit.FromPoint(3);

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0;
            tabla.AddColumn(Unit.FromCentimeter(5));
            tabla.AddColumn(Unit.FromCentimeter(12.9));
            foreach (KeyValuePair<string, string> campo in disponibles)
            {
                Row fila = tabla.AddRow();
                fila.Cells[0].Format.Font.Size = 10;
                fila.Cells[0].Format.Font.Color = Colors.Gray;
                fila.Cells[0].AddParagraph(campo.Key);
                fila.Cells[1].Format.Font.Size = 10.5;
                fila.Cells[1].Format.Font.Color = Colors.Black;
                fila.Cells[1].AddParagraph(campo.Value);
            }
        }

        public static void AgregarTablaDetalleFactura(Section seccion,
            IList<DetalleFacturaDocumento> detalles)
        {
            Paragraph titulo = seccion.AddParagraph("Detalle");
            titulo.Format.Font.Size = 11;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceBefore = Unit.FromPoint(10);
            titulo.Format.SpaceAfter = Unit.FromPoint(5);
            titulo.Format.KeepWithNext = true;

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0.35;
            tabla.Borders.Color = Colors.LightGray;
            tabla.Rows.LeftIndent = Unit.FromPoint(0);
            tabla.AddColumn(Unit.FromCentimeter(1.5));
            tabla.AddColumn(Unit.FromCentimeter(7.2));
            tabla.AddColumn(Unit.FromCentimeter(3));
            tabla.AddColumn(Unit.FromCentimeter(2.7));
            tabla.AddColumn(Unit.FromCentimeter(3.5));

            Row encabezado = tabla.AddRow();
            encabezado.HeadingFormat = true;
            encabezado.Shading.Color = Colors.DarkSlateGray;
            encabezado.Format.Font.Bold = true;
            encabezado.Format.Font.Color = Colors.White;
            encabezado.Format.Font.Size = 9;
            encabezado.VerticalAlignment = VerticalAlignment.Center;
            encabezado.Height = Unit.FromPoint(24);
            string[] titulos = { "Cantidad", "Descripción", "Precio unitario", "Descuento", "Importe" };
            for (int i = 0; i < titulos.Length; i++)
            {
                encabezado.Cells[i].AddParagraph(titulos[i]);
                encabezado.Cells[i].Format.Alignment = i == 1
                    ? ParagraphAlignment.Left : ParagraphAlignment.Right;
            }

            IList<DetalleFacturaDocumento> lineas = detalles ?? new List<DetalleFacturaDocumento>();
            for (int i = 0; i < lineas.Count; i++)
            {
                DetalleFacturaDocumento detalle = lineas[i];
                Row fila = tabla.AddRow();
                fila.Format.Font.Size = 9.5;
                fila.VerticalAlignment = VerticalAlignment.Center;
                if (i % 2 == 1) fila.Shading.Color = Colors.Gainsboro;
                fila.Cells[0].AddParagraph(detalle.Cantidad.ToString("N0", Cultura));
                fila.Cells[1].AddParagraph(detalle.Descripcion ?? string.Empty);
                fila.Cells[2].AddParagraph(FormatearMoneda(detalle.PrecioUnitario));
                fila.Cells[3].AddParagraph(FormatearMoneda(detalle.Descuento));
                fila.Cells[4].AddParagraph(FormatearMoneda(detalle.Cantidad * detalle.PrecioUnitario - detalle.Descuento));
                fila.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                fila.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[4].Format.Alignment = ParagraphAlignment.Right;
            }

            if (lineas.Count == 0)
            {
                Row filaVacia = tabla.AddRow();
                filaVacia.Cells[0].MergeRight = 4;
                filaVacia.Cells[0].AddParagraph("No hay líneas de detalle para esta factura.");
                filaVacia.Cells[0].Format.Font.Color = Colors.Gray;
            }
        }

        public static void AgregarTablaDetalleCompra(Section seccion,
            IList<DetalleCompraDocumento> detalles)
        {
            Paragraph titulo = seccion.AddParagraph("Detalle");
            titulo.Format.Font.Size = 11;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceBefore = Unit.FromPoint(10);
            titulo.Format.SpaceAfter = Unit.FromPoint(5);
            titulo.Format.KeepWithNext = true;

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0.35;
            tabla.Borders.Color = Colors.LightGray;
            tabla.Rows.LeftIndent = Unit.FromPoint(0);
            tabla.AddColumn(Unit.FromCentimeter(5.0));
            tabla.AddColumn(Unit.FromCentimeter(1.8));
            tabla.AddColumn(Unit.FromCentimeter(2.6));
            tabla.AddColumn(Unit.FromCentimeter(2.8));
            tabla.AddColumn(Unit.FromCentimeter(2.6));
            tabla.AddColumn(Unit.FromCentimeter(3.2));

            Row encabezado = tabla.AddRow();
            encabezado.HeadingFormat = true;
            encabezado.Shading.Color = Colors.DarkSlateGray;
            encabezado.Format.Font.Bold = true;
            encabezado.Format.Font.Color = Colors.White;
            encabezado.Format.Font.Size = 8.5;
            encabezado.VerticalAlignment = VerticalAlignment.Center;
            encabezado.Height = Unit.FromPoint(24);
            string[] titulos = { "Material", "Cantidad", "Unidad", "Precio unitario", "Descuento", "Subtotal" };
            for (int i = 0; i < titulos.Length; i++)
            {
                encabezado.Cells[i].AddParagraph(titulos[i]);
                encabezado.Cells[i].Format.Alignment = i == 0 || i == 2
                    ? ParagraphAlignment.Left : ParagraphAlignment.Right;
            }

            IList<DetalleCompraDocumento> lineas = detalles ?? new List<DetalleCompraDocumento>();
            for (int i = 0; i < lineas.Count; i++)
            {
                DetalleCompraDocumento detalle = lineas[i];
                Row fila = tabla.AddRow();
                fila.Format.Font.Size = 9;
                fila.VerticalAlignment = VerticalAlignment.Center;
                if (i % 2 == 1) fila.Shading.Color = Colors.Gainsboro;
                fila.Cells[0].AddParagraph(detalle.NombreMaterial ?? string.Empty);
                fila.Cells[1].AddParagraph(detalle.Cantidad.ToString("N0", Cultura));
                fila.Cells[2].AddParagraph(detalle.UnidadMedida ?? string.Empty);
                fila.Cells[3].AddParagraph(FormatearMoneda(detalle.PrecioUnitario));
                fila.Cells[4].AddParagraph(FormatearMoneda(detalle.Descuento));
                fila.Cells[5].AddParagraph(FormatearMoneda(detalle.Subtotal));
                fila.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                fila.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                fila.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                fila.Cells[5].Format.Alignment = ParagraphAlignment.Right;
            }

            if (lineas.Count == 0)
            {
                Row filaVacia = tabla.AddRow();
                filaVacia.Cells[0].MergeRight = 5;
                filaVacia.Cells[0].AddParagraph("No hay líneas de detalle asociadas a esta compra.");
                filaVacia.Cells[0].Format.Font.Color = Colors.Gray;
            }
        }

        public static void AgregarTotalCompra(Section seccion, decimal total)
        {
            Paragraph titulo = seccion.AddParagraph("Total");
            titulo.Format.Font.Size = 11;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceBefore = Unit.FromPoint(10);
            titulo.Format.SpaceAfter = Unit.FromPoint(4);
            titulo.Format.KeepWithNext = true;

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0;
            tabla.Rows.LeftIndent = Unit.FromCentimeter(8.5);
            tabla.AddColumn(Unit.FromCentimeter(5.5));
            tabla.AddColumn(Unit.FromCentimeter(3.7));
            AgregarFilaTotal(tabla, "Total de la compra", total, true);
        }

        public static void AgregarTotalesFactura(Section seccion, decimal subtotal,
            decimal impuesto, decimal total)
        {
            Paragraph titulo = seccion.AddParagraph("Resumen de totales");
            titulo.Format.Font.Size = 11;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceBefore = Unit.FromPoint(10);
            titulo.Format.SpaceAfter = Unit.FromPoint(4);
            titulo.Format.KeepWithNext = true;

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0;
            tabla.Rows.LeftIndent = Unit.FromCentimeter(8.5);
            tabla.AddColumn(Unit.FromCentimeter(5.5));
            tabla.AddColumn(Unit.FromCentimeter(3.7));

            AgregarFilaTotal(tabla, "Subtotal", subtotal, false);
            AgregarFilaTotal(tabla, "Impuesto", impuesto, false);
            AgregarFilaTotal(tabla, "Total a pagar", total, true);
        }

        static void AgregarFilaTotal(Table tabla, string etiqueta, decimal monto, bool resaltar)
        {
            Row fila = tabla.AddRow();
            if (resaltar) fila.Shading.Color = Colors.Gainsboro;
            fila.Format.Font.Size = resaltar ? 12 : 10.5;
            fila.Format.Font.Bold = resaltar;
            fila.Cells[0].AddParagraph(etiqueta);
            fila.Cells[1].AddParagraph(FormatearMoneda(monto));
            fila.Cells[1].Format.Alignment = ParagraphAlignment.Right;
        }

        public static void AgregarPie(Section seccion, DateTime generado)
        {
            Paragraph pie = seccion.Footers.Primary.AddParagraph();
            pie.Format.Font.Size = 8;
            pie.Format.Font.Color = Colors.Gray;
            pie.Format.Alignment = ParagraphAlignment.Right;
            pie.AddText("Generado: " + generado.ToString("dd/MM/yyyy HH:mm", Cultura) + "    |    Página ");
            pie.AddPageField();
            pie.AddText(" de ");
            pie.AddNumPagesField();
        }

        public static void AgregarFirmasUltimaPagina(PdfDocumentRenderer renderer)
        {
            if (renderer.PdfDocument.PageCount == 0) return;

            PdfSharp.Pdf.PdfPage pagina = renderer.PdfDocument.Pages[renderer.PdfDocument.PageCount - 1];
            double yLinea = pagina.Height.Point - 88;
            double centroPrimera = pagina.Width.Point * 0.29;
            double centroSegunda = pagina.Width.Point * 0.71;
            var fuente = new XFont("Arial", 9, XFontStyleEx.Regular);
            var pluma = new XPen(XColors.Gray, 0.7);
            var pincel = new XSolidBrush(XColors.Gray);
            using (XGraphics grafico = XGraphics.FromPdfPage(pagina, XGraphicsPdfPageOptions.Append))
            {
                grafico.DrawLine(pluma, centroPrimera - 88, yLinea, centroPrimera + 88, yLinea);
                grafico.DrawLine(pluma, centroSegunda - 88, yLinea, centroSegunda + 88, yLinea);
                grafico.DrawString("Elaborado por", fuente, pincel,
                    new XRect(centroPrimera - 88, yLinea + 8, 176, 16), XStringFormats.TopCenter);
                grafico.DrawString("Revisado por", fuente, pincel,
                    new XRect(centroSegunda - 88, yLinea + 8, 176, 16), XStringFormats.TopCenter);
            }
        }

        public static string FormatearMoneda(decimal cantidad)
        {
            return "Q " + cantidad.ToString("N2", Cultura);
        }

        public static string FormatearCantidad(int cantidad, string unidad)
        {
            string texto = cantidad.ToString("N0", Cultura);
            if (string.IsNullOrWhiteSpace(unidad)) return texto;
            string unidadMostrada = unidad.Trim();
            if (cantidad != 1 && !unidadMostrada.EndsWith("s", StringComparison.OrdinalIgnoreCase))
                unidadMostrada += "s";
            return texto + " " + unidadMostrada;
        }

        public static string CrearLogoTemporal()
        {
            const string nombreRecurso = "SistemaPublicidad.Recursos.logo.png";
            using (Stream recurso = Assembly.GetExecutingAssembly().GetManifestResourceStream(nombreRecurso))
            {
                if (recurso == null)
                    throw new InvalidOperationException("No se encontró el logo incrustado de la empresa.");

                string ruta = Path.Combine(Path.GetTempPath(), "PublicidadLogo_" + Guid.NewGuid().ToString("N") + ".png");
                try
                {
                    using (var archivo = new FileStream(ruta, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                        recurso.CopyTo(archivo);
                    return ruta;
                }
                catch
                {
                    if (File.Exists(ruta)) File.Delete(ruta);
                    throw;
                }
            }
        }
    }
}
