using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Entidad;

namespace SistemaPublicidad.Formularios
{
    /// <summary>Genera reportes PDF a partir de las filas que se muestran en la consulta.</summary>
    internal static class ExportadorPdf
    {
        public static void GuardarFactura(FacturaDocumento factura, string ruta)
        {
            if (factura == null) throw new ArgumentNullException("factura");
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentException("Indique dónde guardar el PDF.", "ruta");

            DateTime generado = DateTime.Now;
            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");
            Document documento = PlantillaDocumentosPdf.CrearDocumento("Factura No. " + factura.NoFactura);
            Section seccion = documento.AddSection();
            PlantillaDocumentosPdf.ConfigurarPaginaCarta(seccion);

            string rutaLogo = null;
            try
            {
                rutaLogo = PlantillaDocumentosPdf.AgregarEncabezado(seccion);
                PlantillaDocumentosPdf.AgregarTitulo(seccion, "Factura");
                PlantillaDocumentosPdf.AgregarIdentidadDocumento(seccion,
                    "No. " + factura.NoFactura.ToString(CultureInfo.InvariantCulture));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Datos de la factura",
                    Par("No. factura", factura.NoFactura.ToString(CultureInfo.InvariantCulture)),
                    Par("Fecha de entrega", factura.FechaDeEntrega.ToString("dd 'de' MMMM 'de' yyyy", cultura)),
                    Par("Orden de trabajo", factura.NombreOrdenTrabajo));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Cliente",
                    Par("Nombre", factura.NombreCliente),
                    Par("Identificación", factura.IdentificacionCliente),
                    Par("Dirección", factura.DireccionCliente));
                PlantillaDocumentosPdf.AgregarTablaDetalleFactura(seccion, factura.Detalles);
                PlantillaDocumentosPdf.AgregarTotalesFactura(
                    seccion, factura.Subtotal, factura.Impuesto, factura.TotalPagar);
                PlantillaDocumentosPdf.AgregarPie(seccion, generado);

                var renderer = new PdfDocumentRenderer();
                renderer.Document = documento;
                renderer.RenderDocument();
                PlantillaDocumentosPdf.AgregarFirmasUltimaPagina(renderer);
                renderer.PdfDocument.Save(Path.GetFullPath(ruta));
            }
            finally
            {
                if (rutaLogo != null && File.Exists(rutaLogo))
                    File.Delete(rutaLogo);
            }
        }

        public static void GuardarCompra(CompraDocumento compra, string ruta)
        {
            if (compra == null) throw new ArgumentNullException("compra");
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentException("Indique dónde guardar el PDF.", "ruta");

            DateTime generado = DateTime.Now;
            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");
            string numeroCompra = "COM-" + compra.CodigoCompra.ToString("D6", CultureInfo.InvariantCulture);
            Document documento = PlantillaDocumentosPdf.CrearDocumento("Comprobante de compra " + numeroCompra);
            Section seccion = documento.AddSection();
            PlantillaDocumentosPdf.ConfigurarPaginaCarta(seccion);

            string rutaLogo = null;
            try
            {
                rutaLogo = PlantillaDocumentosPdf.AgregarEncabezado(seccion);
                PlantillaDocumentosPdf.AgregarTitulo(seccion, "Comprobante de compra");
                PlantillaDocumentosPdf.AgregarIdentidadDocumento(seccion, numeroCompra);
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Datos de la compra",
                    Par("Fecha de compra", compra.FechaCompra.ToString("dd 'de' MMMM 'de' yyyy", cultura)),
                    Par("Fecha de entrega", compra.FechaEntrega.ToString("dd 'de' MMMM 'de' yyyy", cultura)),
                    Par("Condición de pago", compra.CondicionPago));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Proveedor",
                    Par("Nombre", compra.NombreProveedor),
                    Par("Teléfono", compra.TelefonoProveedor),
                    Par("Dirección", compra.DireccionProveedor));
                PlantillaDocumentosPdf.AgregarTablaDetalleCompra(seccion, compra.Detalles);
                PlantillaDocumentosPdf.AgregarTotalCompra(seccion, compra.TotalCompra);
                string observaciones = compra.Detalles != null && compra.Detalles.Count == 1
                    ? compra.Detalles[0].Observaciones
                    : null;
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Observaciones",
                    Par("Descripción", observaciones));
                PlantillaDocumentosPdf.AgregarPie(seccion, generado);

                var renderer = new PdfDocumentRenderer();
                renderer.Document = documento;
                renderer.RenderDocument();
                PlantillaDocumentosPdf.AgregarFirmasUltimaPagina(renderer);
                renderer.PdfDocument.Save(Path.GetFullPath(ruta));
            }
            finally
            {
                if (rutaLogo != null && File.Exists(rutaLogo))
                    File.Delete(rutaLogo);
            }
        }

        public static void GuardarFichaInventario(FichaInventario ficha, string ruta)
        {
            if (ficha == null) throw new ArgumentNullException("ficha");
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentException("Indique dónde guardar el PDF.", "ruta");

            DateTime generado = DateTime.Now;
            string codigoVisible = "INV-" + ficha.CodigoInventario.ToString("D6", CultureInfo.InvariantCulture);
            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");

            Document documento = PlantillaDocumentosPdf.CrearDocumento("Ficha de inventario");
            Section seccion = documento.AddSection();
            PlantillaDocumentosPdf.ConfigurarPaginaCarta(seccion);

            string rutaLogo = null;
            try
            {
                rutaLogo = PlantillaDocumentosPdf.AgregarEncabezado(seccion);
                PlantillaDocumentosPdf.AgregarTitulo(seccion, "Ficha de inventario");
                PlantillaDocumentosPdf.AgregarIdentidadProducto(seccion, ficha.NombreProducto, codigoVisible);

                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Producto",
                    Par("Nombre", ficha.NombreProducto),
                    Par("Tipo", ficha.TipoProducto),
                    Par("Material", ficha.NombreMaterial),
                    Par("Unidad de medida", ficha.UnidadMedida));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Existencias",
                    Par("Stock actual", PlantillaDocumentosPdf.FormatearCantidad(ficha.Stock, ficha.UnidadMedida)));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Costos",
                    Par("Costo unitario", PlantillaDocumentosPdf.FormatearMoneda(ficha.PrecioCompra)),
                    Par("Valor total", PlantillaDocumentosPdf.FormatearMoneda(ficha.Stock * ficha.PrecioCompra)));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Ubicación",
                    Par("Sucursal", ficha.NombreSucursal));
                PlantillaDocumentosPdf.AgregarSeccion(seccion, "Fechas",
                    Par("Fecha de ingreso", ficha.FechaIngreso.ToString("dd 'de' MMMM 'de' yyyy", cultura)));
                PlantillaDocumentosPdf.AgregarPie(seccion, generado);

                var renderer = new PdfDocumentRenderer();
                renderer.Document = documento;
                renderer.RenderDocument();
                PlantillaDocumentosPdf.AgregarFirmasUltimaPagina(renderer);
                renderer.PdfDocument.Save(Path.GetFullPath(ruta));
            }
            finally
            {
                if (rutaLogo != null && File.Exists(rutaLogo))
                    File.Delete(rutaLogo);
            }
        }

        static KeyValuePair<string, string> Par(string nombre, string valor)
        {
            return new KeyValuePair<string, string>(nombre, valor);
        }

        public static void GuardarDocumento(string tituloDocumento, string nombreModulo,
            IList<KeyValuePair<string, string>> datos, IList<string> columnasDetalle,
            IList<string[]> filasDetalle, string ruta)
        {
            if (string.IsNullOrWhiteSpace(tituloDocumento)) throw new ArgumentException("Indique el título del documento.", "tituloDocumento");
            if (datos == null) throw new ArgumentNullException("datos");
            if (columnasDetalle == null) throw new ArgumentNullException("columnasDetalle");
            if (filasDetalle == null) throw new ArgumentNullException("filasDetalle");
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentException("Indique dónde guardar el PDF.", "ruta");

            var documento = new Document();
            documento.Info.Title = tituloDocumento;
            documento.Info.Author = "Sistema de Publicidad Multisucursal";
            documento.Styles[StyleNames.Normal].Font.Name = "Arial";
            documento.Styles[StyleNames.Normal].Font.Size = 9;

            Section seccion = documento.AddSection();
            seccion.PageSetup.PageFormat = PageFormat.Letter;
            seccion.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
            seccion.PageSetup.BottomMargin = Unit.FromCentimeter(1.5);
            seccion.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            seccion.PageSetup.RightMargin = Unit.FromCentimeter(1.5);

            Paragraph marca = seccion.AddParagraph("SISTEMA DE PUBLICIDAD MULTISUCURSAL");
            marca.Format.Font.Size = 9;
            marca.Format.Font.Bold = true;
            marca.Format.Font.Color = Colors.DarkBlue;
            marca.Format.SpaceAfter = Unit.FromPoint(10);

            Paragraph titulo = seccion.AddParagraph(tituloDocumento);
            titulo.Format.Font.Size = 20;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceAfter = Unit.FromPoint(4);

            Paragraph fecha = seccion.AddParagraph(nombreModulo + "    |    Generado: " +
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            fecha.Format.Font.Size = 8;
            fecha.Format.Font.Color = Colors.Gray;
            fecha.Format.SpaceAfter = Unit.FromPoint(14);

            Paragraph encabezadoDatos = seccion.AddParagraph("Datos del registro");
            encabezadoDatos.Format.Font.Size = 12;
            encabezadoDatos.Format.Font.Bold = true;
            encabezadoDatos.Format.SpaceAfter = Unit.FromPoint(5);

            var tablaDatos = seccion.AddTable();
            tablaDatos.Borders.Width = 0.5;
            tablaDatos.Borders.Color = Colors.LightGray;
            tablaDatos.AddColumn(Unit.FromCentimeter(5));
            tablaDatos.AddColumn(Unit.FromCentimeter(13.5));
            for (int i = 0; i < datos.Count; i++)
            {
                Row filaDatos = tablaDatos.AddRow();
                if (i % 2 == 1) filaDatos.Shading.Color = Colors.AliceBlue;
                filaDatos.Cells[0].Format.Font.Bold = true;
                filaDatos.Cells[0].AddParagraph(datos[i].Key ?? string.Empty);
                filaDatos.Cells[1].AddParagraph(datos[i].Value ?? string.Empty);
            }

            if (columnasDetalle.Count > 0)
            {
                Paragraph encabezadoDetalle = seccion.AddParagraph("Detalle");
                encabezadoDetalle.Format.Font.Size = 12;
                encabezadoDetalle.Format.Font.Bold = true;
                encabezadoDetalle.Format.SpaceBefore = Unit.FromPoint(14);
                encabezadoDetalle.Format.SpaceAfter = Unit.FromPoint(5);

                if (filasDetalle.Count == 0)
                {
                    seccion.AddParagraph("No hay líneas de detalle asociadas a este registro.");
                }
                else
                {
                    var tablaDetalle = seccion.AddTable();
                    tablaDetalle.Borders.Width = 0.5;
                    tablaDetalle.Borders.Color = Colors.LightGray;
                    tablaDetalle.Rows.LeftIndent = Unit.FromPoint(0);
                    double anchoDisponible = 21.59 - 3.0;
                    for (int i = 0; i < columnasDetalle.Count; i++)
                        tablaDetalle.AddColumn(Unit.FromCentimeter(anchoDisponible / columnasDetalle.Count));

                    Row filaEncabezado = tablaDetalle.AddRow();
                    filaEncabezado.HeadingFormat = true;
                    filaEncabezado.Shading.Color = Colors.DarkBlue;
                    filaEncabezado.Format.Font.Bold = true;
                    filaEncabezado.Format.Font.Color = Colors.White;
                    filaEncabezado.Format.Font.Size = 8;
                    for (int i = 0; i < columnasDetalle.Count; i++)
                        filaEncabezado.Cells[i].AddParagraph(columnasDetalle[i] ?? string.Empty);

                    for (int r = 0; r < filasDetalle.Count; r++)
                    {
                        string[] valores = filasDetalle[r] ?? new string[0];
                        Row filaDetalle = tablaDetalle.AddRow();
                        filaDetalle.Format.Font.Size = 8;
                        if (r % 2 == 1) filaDetalle.Shading.Color = Colors.AliceBlue;
                        for (int c = 0; c < columnasDetalle.Count; c++)
                            filaDetalle.Cells[c].AddParagraph(c < valores.Length ? valores[c] ?? string.Empty : string.Empty);
                    }
                }
            }

            Paragraph pie = seccion.Footers.Primary.AddParagraph("Sistema de Publicidad Multisucursal");
            pie.Format.Font.Size = 8;
            pie.Format.Font.Color = Colors.Gray;
            pie.Format.Alignment = ParagraphAlignment.Right;

            var renderer = new PdfDocumentRenderer();
            renderer.Document = documento;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path.GetFullPath(ruta));
        }

        public static void Guardar(string nombreModulo, IList<Tabla.Col> columnas, IList<string[]> filas, int pagina, string ruta)
        {
            if (columnas == null) throw new ArgumentNullException("columnas");
            if (filas == null) throw new ArgumentNullException("filas");
            if (string.IsNullOrWhiteSpace(ruta)) throw new ArgumentException("Indique dónde guardar el PDF.", "ruta");

            var documento = new Document();
            documento.Info.Title = "Reporte de " + nombreModulo;
            documento.Info.Author = "Sistema de Publicidad Multisucursal";
            documento.Styles[StyleNames.Normal].Font.Name = "Arial";
            documento.Styles[StyleNames.Normal].Font.Size = 9;

            Section seccion = documento.AddSection();
            seccion.PageSetup.Orientation = Orientation.Landscape;
            seccion.PageSetup.PageFormat = PageFormat.Letter;
            seccion.PageSetup.TopMargin = Unit.FromCentimeter(1.6);
            seccion.PageSetup.BottomMargin = Unit.FromCentimeter(1.6);
            seccion.PageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            seccion.PageSetup.RightMargin = Unit.FromCentimeter(1.5);

            Paragraph titulo = seccion.AddParagraph("Reporte de " + nombreModulo);
            titulo.Format.Font.Size = 18;
            titulo.Format.Font.Bold = true;
            titulo.Format.Font.Color = Colors.DarkBlue;
            titulo.Format.SpaceAfter = Unit.FromPoint(4);

            Paragraph info = seccion.AddParagraph("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                "    |    Página de consulta: " + pagina + "    |    Registros: " + filas.Count);
            info.Format.Font.Size = 8;
            info.Format.Font.Color = Colors.Gray;
            info.Format.SpaceAfter = Unit.FromPoint(12);

            var tabla = seccion.AddTable();
            tabla.Borders.Width = 0.5;
            tabla.Borders.Color = Colors.LightGray;
            tabla.Rows.LeftIndent = Unit.FromPoint(0);
            float anchoDisponible = 792f - 2f * 42.5f;
            float anchoColumna = anchoDisponible / Math.Max(1, columnas.Count);
            for (int i = 0; i < columnas.Count; i++)
                tabla.AddColumn(Unit.FromPoint(anchoColumna));

            Row encabezado = tabla.AddRow();
            encabezado.HeadingFormat = true;
            encabezado.Shading.Color = Colors.DarkBlue;
            encabezado.Format.Font.Bold = true;
            encabezado.Format.Font.Color = Colors.White;
            encabezado.Format.Font.Size = 8;
            encabezado.Height = Unit.FromPoint(24);
            encabezado.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < columnas.Count; i++)
                encabezado.Cells[i].AddParagraph(columnas[i].Titulo ?? string.Empty);

            for (int r = 0; r < filas.Count; r++)
            {
                string[] fila = filas[r] ?? new string[0];
                Row filaPdf = tabla.AddRow();
                filaPdf.VerticalAlignment = VerticalAlignment.Center;
                filaPdf.Format.Font.Size = 8;
                if (r % 2 == 1) filaPdf.Shading.Color = Colors.AliceBlue;
                for (int c = 0; c < columnas.Count; c++)
                {
                    // La primera y última celdas son controles internos de la tabla del sistema.
                    int indice = c + 1;
                    string valor = indice < fila.Length - 1 ? fila[indice] : string.Empty;
                    filaPdf.Cells[c].AddParagraph(valor ?? string.Empty);
                }
            }

            Paragraph pie = seccion.Footers.Primary.AddParagraph("Sistema de Publicidad Multisucursal");
            pie.Format.Font.Size = 8;
            pie.Format.Font.Color = Colors.Gray;
            pie.Format.Alignment = ParagraphAlignment.Right;

            var renderer = new PdfDocumentRenderer();
            renderer.Document = documento;
            renderer.RenderDocument();
            string destino = Path.GetFullPath(ruta);
            renderer.PdfDocument.Save(destino);
        }
    }
}
