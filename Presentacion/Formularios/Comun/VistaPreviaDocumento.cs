using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Entidad;

namespace SistemaPublicidad.Formularios
{
    internal sealed class VistaPreviaDocumento : Form
    {
        public VistaPreviaDocumento(FacturaDocumento factura)
        {
            if (factura == null) throw new ArgumentNullException("factura");

            Text = "Vista previa - Factura No. " + factura.NoFactura;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            ShowInTaskbar = false;
            MinimumSize = new Size(760, 680);
            Size = new Size(900, 820);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(35, 43, 54);
            Font = Tema.F(9);

            var raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(22)
            };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 66));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));

            var contenido = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(2, 2, 10, 10)
            };
            var encabezado = CrearEncabezadoVistaPrevia();
            contenido.Controls.Add(encabezado);
            contenido.Controls.Add(new Label
            {
                Text = "Factura",
                Font = Tema.F(20, true),
                ForeColor = Color.FromArgb(35, 55, 90),
                AutoSize = true,
                Margin = new Padding(0, 14, 0, 2)
            });
            contenido.Controls.Add(new Label
            {
                Text = "No. " + factura.NoFactura.ToString(CultureInfo.InvariantCulture),
                Font = Tema.F(12),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 8)
            });

            contenido.Controls.Add(SeccionFicha("Datos de la factura", new[]
            {
                ParFicha("No. factura", factura.NoFactura.ToString(CultureInfo.InvariantCulture)),
                ParFicha("Fecha de entrega", factura.FechaDeEntrega.ToString("dd 'de' MMMM 'de' yyyy",
                    CultureInfo.GetCultureInfo("es-GT"))),
                ParFicha("Orden de trabajo", factura.NombreOrdenTrabajo)
            }));
            contenido.Controls.Add(SeccionFicha("Cliente", new[]
            {
                ParFicha("Nombre", factura.NombreCliente),
                ParFicha("Identificación", factura.IdentificacionCliente),
                ParFicha("Dirección", factura.DireccionCliente)
            }));
            contenido.Controls.Add(SeccionDetalleFactura(factura.Detalles));
            contenido.Controls.Add(SeccionTotalesFactura(factura));

            var firmas = CrearBloqueFirmasVistaPrevia();
            var acciones = CrearAccionesVistaPrevia();
            raiz.Controls.Add(contenido, 0, 1);
            raiz.Controls.Add(firmas, 0, 2);
            raiz.Controls.Add(acciones, 0, 3);
            Controls.Add(raiz);
            AcceptButton = acciones.Controls["guardarPdf"] as Button;
            CancelButton = acciones.Controls["cancelar"] as Button;
        }

        public VistaPreviaDocumento(CompraDocumento compra)
        {
            if (compra == null) throw new ArgumentNullException("compra");

            string numeroCompra = "COM-" + compra.CodigoCompra.ToString("D6", CultureInfo.InvariantCulture);
            Text = "Vista previa - Comprobante de compra " + numeroCompra;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            ShowInTaskbar = false;
            MinimumSize = new Size(760, 680);
            Size = new Size(900, 820);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(35, 43, 54);
            Font = Tema.F(9);

            var raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(22)
            };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 66));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));

            var contenido = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(2, 2, 10, 10)
            };
            contenido.Controls.Add(CrearEncabezadoVistaPrevia());
            contenido.Controls.Add(new Label
            {
                Text = "Comprobante de compra",
                Font = Tema.F(20, true),
                ForeColor = Color.FromArgb(35, 55, 90),
                AutoSize = true,
                Margin = new Padding(0, 14, 0, 2)
            });
            contenido.Controls.Add(new Label
            {
                Text = numeroCompra,
                Font = Tema.F(12),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 8)
            });

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");
            contenido.Controls.Add(SeccionFicha("Datos de la compra", new[]
            {
                ParFicha("Fecha de compra", compra.FechaCompra.ToString("dd 'de' MMMM 'de' yyyy", cultura)),
                ParFicha("Fecha de entrega", compra.FechaEntrega.ToString("dd 'de' MMMM 'de' yyyy", cultura)),
                ParFicha("Condición de pago", compra.CondicionPago)
            }));
            contenido.Controls.Add(SeccionFicha("Proveedor", new[]
            {
                ParFicha("Nombre", compra.NombreProveedor),
                ParFicha("Teléfono", compra.TelefonoProveedor),
                ParFicha("Dirección", compra.DireccionProveedor)
            }));
            contenido.Controls.Add(SeccionDetalleCompra(compra.Detalles));
            contenido.Controls.Add(SeccionTotalCompra(compra.TotalCompra));
            string observaciones = compra.Detalles != null && compra.Detalles.Count == 1
                ? compra.Detalles[0].Observaciones
                : null;
            contenido.Controls.Add(SeccionFicha("Observaciones", new[]
            {
                ParFicha("Descripción", observaciones)
            }));

            var firmas = CrearBloqueFirmasVistaPrevia();
            var acciones = CrearAccionesVistaPrevia();
            raiz.Controls.Add(contenido, 0, 1);
            raiz.Controls.Add(firmas, 0, 2);
            raiz.Controls.Add(acciones, 0, 3);
            Controls.Add(raiz);
            AcceptButton = acciones.Controls["guardarPdf"] as Button;
            CancelButton = acciones.Controls["cancelar"] as Button;
        }

        public VistaPreviaDocumento(FichaInventario ficha)
        {
            if (ficha == null) throw new System.ArgumentNullException("ficha");

            Text = "Vista previa - Ficha de inventario";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            ShowInTaskbar = false;
            MinimumSize = new Size(760, 620);
            Size = new Size(900, 760);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(35, 43, 54);
            Font = Tema.F(9);

            var raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(22)
            };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 66));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));

            var contenido = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(2, 2, 10, 10)
            };

            var encabezado = CrearEncabezadoVistaPrevia();
            contenido.Controls.Add(encabezado);

            contenido.Controls.Add(new Label
            {
                Text = "Ficha de inventario",
                Font = Tema.F(20, true),
                ForeColor = Color.FromArgb(35, 55, 90),
                AutoSize = true,
                Margin = new Padding(0, 14, 0, 8)
            });

            var identidad = new Panel { Width = 820, Height = 48, BackColor = Color.White };
            identidad.Controls.Add(new Label
            {
                Text = ficha.NombreProducto ?? string.Empty,
                Font = Tema.F(14, true),
                ForeColor = Color.FromArgb(30, 35, 42),
                AutoSize = true,
                Left = 0,
                Top = 0
            });
            identidad.Controls.Add(new Label
            {
                Text = "Código: INV-" + ficha.CodigoInventario.ToString("D6", CultureInfo.InvariantCulture),
                Font = Tema.F(9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Left = 0,
                Top = 30
            });
            contenido.Controls.Add(identidad);

            contenido.Controls.Add(SeccionFicha("Producto", new[]
            {
                ParFicha("Nombre", ficha.NombreProducto),
                ParFicha("Tipo", ficha.TipoProducto),
                ParFicha("Material", ficha.NombreMaterial),
                ParFicha("Unidad de medida", ficha.UnidadMedida)
            }));
            contenido.Controls.Add(SeccionFicha("Existencias", new[]
            {
                ParFicha("Stock actual", FormatearCantidad(ficha.Stock, ficha.UnidadMedida))
            }));
            contenido.Controls.Add(SeccionFicha("Costos", new[]
            {
                ParFicha("Costo unitario", FormatearMoneda(ficha.PrecioCompra)),
                ParFicha("Valor total", FormatearMoneda(ficha.Stock * ficha.PrecioCompra))
            }));
            contenido.Controls.Add(SeccionFicha("Ubicación", new[]
            {
                ParFicha("Sucursal", ficha.NombreSucursal)
            }));
            contenido.Controls.Add(SeccionFicha("Fechas", new[]
            {
                ParFicha("Fecha de ingreso", ficha.FechaIngreso.ToString("dd 'de' MMMM 'de' yyyy",
                    CultureInfo.GetCultureInfo("es-GT")))
            }));

            var firmas = CrearBloqueFirmasVistaPrevia();

            var acciones = CrearAccionesVistaPrevia();

            raiz.Controls.Add(contenido, 0, 1);
            raiz.Controls.Add(firmas, 0, 2);
            raiz.Controls.Add(acciones, 0, 3);
            Controls.Add(raiz);
            AcceptButton = acciones.Controls["guardarPdf"] as Button;
            CancelButton = acciones.Controls["cancelar"] as Button;
        }

        public VistaPreviaDocumento(string titulo, IList<KeyValuePair<string, string>> datos,
            IList<string> columnasDetalle, IList<string[]> filasDetalle)
        {
            Text = "Vista previa";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            ShowInTaskbar = false;
            MinimumSize = new Size(720, 560);
            Size = new Size(900, 700);
            BackColor = Tema.Fondo;
            ForeColor = Color.White;
            Font = Tema.F(9);

            var contenido = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Tema.Fondo,
                ColumnCount = 1,
                RowCount = columnasDetalle.Count > 0 ? 4 : 3,
                Padding = new Padding(18)
            };
            contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 210));
            if (columnasDetalle.Count > 0)
            {
                contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            }
            else
            {
                contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            }

            var tituloLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = titulo,
                Font = Tema.F(17, true),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };
            contenido.Controls.Add(tituloLabel, 0, 0);

            var tablaDatos = CrearTabla();
            tablaDatos.Columns.Add("Campo", "Campo");
            tablaDatos.Columns.Add("Valor", "Valor");
            tablaDatos.Columns[0].FillWeight = 35;
            tablaDatos.Columns[1].FillWeight = 65;
            foreach (KeyValuePair<string, string> dato in datos)
                tablaDatos.Rows.Add(dato.Key, dato.Value);
            contenido.Controls.Add(Grupo("Datos del registro", tablaDatos), 0, 1);

            if (columnasDetalle.Count > 0)
            {
                Control contenidoDetalle;
                if (filasDetalle.Count == 0)
                {
                    contenidoDetalle = new Label
                    {
                        Dock = DockStyle.Fill,
                        Text = "No hay líneas de detalle asociadas a este registro.",
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Tema.Sub,
                        BackColor = Color.FromArgb(14, 27, 88)
                    };
                }
                else
                {
                    var tablaDetalle = CrearTabla();
                    for (int i = 0; i < columnasDetalle.Count; i++)
                        tablaDetalle.Columns.Add("detalle" + i, columnasDetalle[i]);
                    foreach (string[] fila in filasDetalle)
                        tablaDetalle.Rows.Add(fila);
                    contenidoDetalle = tablaDetalle;
                }
                contenido.Controls.Add(Grupo("Detalle", contenidoDetalle), 0, 2);
            }

            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 12, 0, 0)
            };
            var guardar = new Button
            {
                Text = "Guardar PDF",
                Width = 120,
                Height = 34,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0, 150, 145),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            guardar.FlatAppearance.BorderSize = 0;
            var cancelar = new Button
            {
                Text = "Cancelar",
                Width = 100,
                Height = 34,
                DialogResult = DialogResult.Cancel,
                BackColor = Tema.Campo,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 10, 0)
            };
            cancelar.FlatAppearance.BorderSize = 0;
            acciones.Controls.Add(guardar);
            acciones.Controls.Add(cancelar);
            contenido.Controls.Add(acciones, 0, columnasDetalle.Count > 0 ? 3 : 2);

            Controls.Add(contenido);
            AcceptButton = guardar;
            CancelButton = cancelar;
        }

        static Panel CrearEncabezadoVistaPrevia()
        {
            var encabezado = new Panel { Width = 820, Height = 58, BackColor = Color.White };
            var logo = Recursos.Img("logo");
            if (logo != null)
                encabezado.Controls.Add(new PictureBox
                {
                    Image = logo,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 48,
                    Height = 48,
                    Left = 0,
                    Top = 4
                });
            encabezado.Controls.Add(new Label
            {
                Text = "Sistema de Publicidad Multisucursal",
                Font = Tema.F(12, true),
                ForeColor = Color.FromArgb(35, 55, 90),
                AutoSize = true,
                Left = logo == null ? 0 : 60,
                Top = 18
            });
            return encabezado;
        }

        static GroupBox SeccionDetalleFactura(IEnumerable<DetalleFacturaDocumento> detalles)
        {
            var tabla = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(220, 224, 229),
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(70, 78, 88),
                ForeColor = Color.White,
                Font = Tema.F(9, true),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            tabla.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(35, 43, 54),
                SelectionBackColor = Color.FromArgb(230, 235, 241),
                SelectionForeColor = Color.FromArgb(35, 43, 54),
                WrapMode = DataGridViewTriState.True
            };
            tabla.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(246, 247, 249),
                ForeColor = Color.FromArgb(35, 43, 54),
                SelectionBackColor = Color.FromArgb(230, 235, 241),
                SelectionForeColor = Color.FromArgb(35, 43, 54),
                WrapMode = DataGridViewTriState.True
            };
            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns.Add("Descripcion", "Descripción");
            tabla.Columns.Add("Precio", "Precio unitario");
            tabla.Columns.Add("Descuento", "Descuento");
            tabla.Columns.Add("Importe", "Importe");
            tabla.Columns["Cantidad"].FillWeight = 12;
            tabla.Columns["Descripcion"].FillWeight = 38;
            tabla.Columns["Precio"].FillWeight = 18;
            tabla.Columns["Descuento"].FillWeight = 16;
            tabla.Columns["Importe"].FillWeight = 18;
            foreach (string nombreColumna in new[] { "Cantidad", "Precio", "Descuento", "Importe" })
                tabla.Columns[nombreColumna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");
            foreach (DetalleFacturaDocumento detalle in detalles ?? Enumerable.Empty<DetalleFacturaDocumento>())
            {
                decimal importe = detalle.Cantidad * detalle.PrecioUnitario - detalle.Descuento;
                tabla.Rows.Add(
                    detalle.Cantidad.ToString("N0", cultura),
                    detalle.Descripcion ?? string.Empty,
                    FormatearMoneda(detalle.PrecioUnitario),
                    FormatearMoneda(detalle.Descuento),
                    FormatearMoneda(importe));
            }

            var grupo = new GroupBox
            {
                Text = "Detalle",
                ForeColor = Color.FromArgb(35, 55, 90),
                BackColor = Color.White,
                Width = 820,
                Height = 280,
                Padding = new Padding(10)
            };
            grupo.Controls.Add(tabla);
            return grupo;
        }

        static GroupBox SeccionDetalleCompra(IEnumerable<DetalleCompraDocumento> detalles)
        {
            var tabla = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(220, 224, 229),
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(70, 78, 88),
                ForeColor = Color.White,
                Font = Tema.F(9, true),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            tabla.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(35, 43, 54),
                SelectionBackColor = Color.FromArgb(230, 235, 241),
                SelectionForeColor = Color.FromArgb(35, 43, 54),
                WrapMode = DataGridViewTriState.True
            };
            tabla.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(246, 247, 249),
                ForeColor = Color.FromArgb(35, 43, 54),
                SelectionBackColor = Color.FromArgb(230, 235, 241),
                SelectionForeColor = Color.FromArgb(35, 43, 54),
                WrapMode = DataGridViewTriState.True
            };
            tabla.Columns.Add("Material", "Material");
            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns.Add("Unidad", "Unidad");
            tabla.Columns.Add("Precio", "Precio unitario");
            tabla.Columns.Add("Descuento", "Descuento");
            tabla.Columns.Add("Subtotal", "Subtotal");
            tabla.Columns["Material"].FillWeight = 26;
            tabla.Columns["Cantidad"].FillWeight = 12;
            tabla.Columns["Unidad"].FillWeight = 16;
            tabla.Columns["Precio"].FillWeight = 17;
            tabla.Columns["Descuento"].FillWeight = 14;
            tabla.Columns["Subtotal"].FillWeight = 15;

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-GT");
            foreach (DetalleCompraDocumento detalle in detalles ?? Enumerable.Empty<DetalleCompraDocumento>())
            {
                tabla.Rows.Add(
                    detalle.NombreMaterial ?? string.Empty,
                    detalle.Cantidad.ToString("N0", cultura),
                    detalle.UnidadMedida ?? string.Empty,
                    FormatearMoneda(detalle.PrecioUnitario),
                    FormatearMoneda(detalle.Descuento),
                    FormatearMoneda(detalle.Subtotal));
            }

            var grupo = new GroupBox
            {
                Text = "Detalle",
                ForeColor = Color.FromArgb(35, 55, 90),
                BackColor = Color.White,
                Width = 820,
                Height = 280,
                Padding = new Padding(10)
            };
            grupo.Controls.Add(tabla);
            return grupo;
        }

        static GroupBox SeccionTotalCompra(decimal total)
        {
            var tabla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.White,
                Padding = new Padding(4, 2, 4, 2)
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            AgregarFilaTotal(tabla, 0, "Total de la compra", total, true);

            var grupo = new GroupBox
            {
                Text = "Total",
                ForeColor = Color.FromArgb(35, 55, 90),
                BackColor = Color.White,
                Width = 820,
                Height = 72,
                Padding = new Padding(10)
            };
            grupo.Controls.Add(tabla);
            return grupo;
        }

        static GroupBox SeccionTotalesFactura(FacturaDocumento factura)
        {
            var tabla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                BackColor = Color.White,
                Padding = new Padding(4, 2, 4, 2)
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 34));
            AgregarFilaTotal(tabla, 0, "Subtotal", factura.Subtotal, false);
            AgregarFilaTotal(tabla, 1, "Impuesto", factura.Impuesto, false);
            AgregarFilaTotal(tabla, 2, "Total a pagar", factura.TotalPagar, true);

            var grupo = new GroupBox
            {
                Text = "Totales",
                ForeColor = Color.FromArgb(35, 55, 90),
                BackColor = Color.White,
                Width = 820,
                Height = 125,
                Padding = new Padding(10)
            };
            grupo.Controls.Add(tabla);
            return grupo;
        }

        static void AgregarFilaTotal(TableLayoutPanel tabla, int fila, string titulo, decimal cantidad, bool principal)
        {
            Font fuente = Tema.F(principal ? 11 : 9, principal);
            tabla.Controls.Add(new Label
            {
                Text = titulo,
                Font = fuente,
                ForeColor = principal ? Color.FromArgb(35, 43, 54) : Color.Gray,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            }, 0, fila);
            tabla.Controls.Add(new Label
            {
                Text = FormatearMoneda(cantidad),
                Font = fuente,
                ForeColor = Color.FromArgb(30, 35, 42),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            }, 1, fila);
        }

        static TableLayoutPanel CrearBloqueFirmasVistaPrevia()
        {
            var firmas = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(8, 2, 8, 2)
            };
            firmas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            firmas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            firmas.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
            firmas.RowStyles.Add(new RowStyle(SizeType.Absolute, 24));
            firmas.Controls.Add(new Label
            {
                Text = "________________________________",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.Fill
            }, 0, 0);
            firmas.Controls.Add(new Label
            {
                Text = "________________________________",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.Fill
            }, 1, 0);
            firmas.Controls.Add(new Label
            {
                Text = "Elaborado por",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill
            }, 0, 1);
            firmas.Controls.Add(new Label
            {
                Text = "Revisado por",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill
            }, 1, 1);
            return firmas;
        }

        static FlowLayoutPanel CrearAccionesVistaPrevia()
        {
            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = Color.White,
                Padding = new Padding(0, 10, 0, 0)
            };
            var guardar = new Button
            {
                Name = "guardarPdf",
                Text = "Guardar PDF",
                Width = 120,
                Height = 34,
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(35, 80, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            guardar.FlatAppearance.BorderSize = 0;
            var cancelar = new Button
            {
                Name = "cancelar",
                Text = "Cancelar",
                Width = 100,
                Height = 34,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(235, 238, 242),
                ForeColor = Color.FromArgb(45, 52, 62),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 10, 0)
            };
            cancelar.FlatAppearance.BorderSize = 0;
            acciones.Controls.Add(guardar);
            acciones.Controls.Add(cancelar);
            return acciones;
        }

        static GroupBox Grupo(string titulo, Control contenido)
        {
            var grupo = new GroupBox
            {
                Dock = DockStyle.Fill,
                Text = titulo,
                ForeColor = Tema.Cian,
                BackColor = Color.Transparent,
                Padding = new Padding(10)
            };
            contenido.Dock = DockStyle.Fill;
            grupo.Controls.Add(contenido);
            return grupo;
        }

        static GroupBox SeccionFicha(string titulo, IEnumerable<KeyValuePair<string, string>> campos)
        {
            KeyValuePair<string, string>[] disponibles = campos
                .Where(campo => !string.IsNullOrWhiteSpace(campo.Value)).ToArray();
            var tabla = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = Math.Max(1, disponibles.Length),
                BackColor = Color.White,
                Padding = new Padding(4)
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < disponibles.Length; i++)
            {
                KeyValuePair<string, string> campo = disponibles[i];
                tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
                tabla.Controls.Add(new Label
                {
                    Text = campo.Key,
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill
                }, 0, i);
                tabla.Controls.Add(new Label
                {
                    Text = campo.Value,
                    ForeColor = Color.FromArgb(30, 35, 42),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill
                }, 1, i);
            }
            var grupo = new GroupBox
            {
                Text = titulo,
                ForeColor = Color.FromArgb(35, 55, 90),
                BackColor = Color.White,
                Width = 820,
                Height = Math.Max(70, 28 * disponibles.Length + 36),
                Padding = new Padding(10)
            };
            tabla.Dock = DockStyle.Fill;
            grupo.Controls.Add(tabla);
            return grupo;
        }

        static KeyValuePair<string, string> ParFicha(string nombre, string valor)
        {
            return new KeyValuePair<string, string>(nombre, valor);
        }

        static string FormatearCantidad(int cantidad, string unidad)
        {
            string texto = cantidad.ToString("N0", CultureInfo.GetCultureInfo("es-GT"));
            if (string.IsNullOrWhiteSpace(unidad)) return texto;
            string unidadMostrada = unidad.Trim();
            if (cantidad != 1 && !unidadMostrada.EndsWith("s", StringComparison.OrdinalIgnoreCase))
                unidadMostrada += "s";
            return texto + " " + unidadMostrada;
        }

        static string FormatearMoneda(decimal cantidad)
        {
            return "Q " + cantidad.ToString("N2", CultureInfo.GetCultureInfo("es-GT"));
        }

        static DataGridView CrearTabla()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                BackgroundColor = Color.FromArgb(14, 27, 88),
                BorderStyle = BorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(55, 75, 135),
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(35, 55, 125),
                    ForeColor = Color.White,
                    Font = Tema.F(9, true)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(14, 27, 88),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(65, 75, 155),
                    SelectionForeColor = Color.White,
                    WrapMode = DataGridViewTriState.True
                },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(20, 38, 105),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(65, 75, 155),
                    SelectionForeColor = Color.White
                }
            };
        }
    }
}
