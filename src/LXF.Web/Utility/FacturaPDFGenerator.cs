using LXF.Web.Models.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

public class FacturaPDFGenerator
{
    private static readonly CultureInfo culturaArg = new CultureInfo("es-AR");
    public static byte[] CreateFacturaPDF(ComprobanteGetViewModel model, string rutaLogoPath)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0.8f, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Arial));

                page.Header().Element(h => BuildHeader(h, model, rutaLogoPath));
                page.Content().Element(c => BuildBody(c, model));
                page.Footer().Element(f => BuildFooter(f, model));
            });
        });

        return document.GeneratePdf();
    }

    private static void BuildHeader(IContainer container, ComprobanteGetViewModel model, string rutaLogoPath)
    {
        container.Border(1).BorderColor(Colors.Black).Padding(4).Row(row =>
        {
            // Columna Izquierda: Logo y Emisor
            row.RelativeItem().Column(col =>
            {
                col.Item().Row(r =>
                {
                    r.ConstantItem(50).Height(50).AlignCenter().AlignMiddle().Text("LXF").FontColor(Colors.Black).FontSize(24).Bold();

                    r.RelativeItem().PaddingLeft(5).Column(c =>
                    {
                        c.Item().Text("LOCOS X EL FÚTBOL STORE S.A.").Bold().FontSize(10).AlignCenter();
                        c.Item().Text("CASA CENTRAL").FontSize(7).AlignCenter();
                        c.Item().PaddingTop(8).Text("TEL: 0381 4567890").FontSize(8).AlignCenter();
                    });
                });
            });

            // Centro: Letra B
            row.ConstantItem(45).Border(1).BorderColor(Colors.Black).AlignCenter().AlignMiddle().Column(col =>
            {
                col.Item().Text("B").Bold().FontSize(18).AlignCenter();
                col.Item().Text("Cod. 006").FontSize(7).AlignCenter();
            });

            // Columna Derecha: Datos de la Factura
            row.RelativeItem().PaddingLeft(10).Column(col =>
            {
                col.Item().Text("FACTURA").Bold().FontSize(14).AlignRight();
                col.Item().Text($"N° 00001-{model.Id:D8}").Bold().FontSize(11).AlignRight(); // Formateado a 8 dígitos dinámicos
                col.Item().Text($"FECHA: {model.Fecha}").Bold().FontSize(10).AlignRight();
                col.Item().PaddingTop(3).Text("RESPONSABLE INSCRIPTO  CUIT: 30-71234567-8").FontSize(7).AlignRight();
                col.Item().Text("INICIO ACT.: 01/01/2026  ING. BRUTOS: 30-71234567-8").FontSize(7).AlignRight();
            });
        });
    }

    private static void BuildBody(IContainer container, ComprobanteGetViewModel model)
    {
        container.PaddingTop(5).Column(col =>
        {
            col.Item().Border(1).BorderColor(Colors.Black).Padding(4).Column(c =>
            {
                c.Item().Row(r =>
                {
                    r.RelativeItem(1.3f).Text(t =>
                    {
                        t.Span("SEÑOR/ES: ").Bold();
                        t.Span((model.Factura?.Nombre ?? model.Envio?.Persona ?? "CONSUMIDOR FINAL").ToUpper());
                    });
                    r.RelativeItem(0.9f).Text(t =>
                    {
                        t.Span("IVA: ").Bold();
                        t.Span("CONSUMIDOR FINAL");
                    });
                    r.RelativeItem(0.8f).Text(t =>
                    {
                        t.Span("DNI: ").Bold();
                        t.Span(model.Factura?.Dni ?? model.Envio?.Dni ?? "-");
                    });
                });

                c.Item().Row(r =>
                {
                    r.RelativeItem(1.3f).Text(t =>
                    {
                        t.Span("DOMICILIO: ").Bold();
                        t.Span((model.Factura?.Direccion ?? model.Envio?.Direccion ?? "-").ToUpper());
                    });
                    r.RelativeItem(0.9f).Text(t =>
                    {
                        t.Span("LOCALIDAD: ").Bold();
                        t.Span("SAN MIGUEL DE TUCUMAN");
                    });
                    r.RelativeItem(0.8f).Text(t =>
                    {
                        t.Span("PROVINCIA: ").Bold();
                        t.Span("TUCUMAN");
                    });
                });

                c.Item().Row(r =>
                {
                    r.RelativeItem(1.3f).Text(t =>
                    {
                        t.Span("CORREO ELECTRONICO: ").Bold();
                        t.Span((model.Factura?.Email ?? model.Envio?.Email ?? "-").ToLower());
                    });
                    r.RelativeItem(1.7f).Text(t =>
                    {
                        t.Span("CONDICION PAGO: ").Bold();
                        t.Span((model.Factura?.TipoPago ?? "MERCADO PAGO").ToUpper());
                    });
                });

                c.Item().BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(2).Text(t =>
                {
                    t.Span("OBSERVACIONES: ").Bold();
                    t.Span("ENTREGA EN PAQUETE UNICO - LOCOS X EL FUTBOL STORE");
                });
            });

            // Tabla de Productos con datos del ViewModel
            col.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(4);
                    columns.ConstantColumn(45);
                    columns.ConstantColumn(70);
                    columns.ConstantColumn(70);
                });

                table.Header(header =>
                {
                    header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Black).Padding(2).AlignCenter().Text("Descripción").Bold();
                    header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Black).Padding(2).AlignCenter().Text("Cant.").Bold();
                    header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Black).Padding(2).AlignCenter().Text("Precio Uni.").Bold();
                    header.Cell().Background(Colors.Grey.Lighten2).Border(1).BorderColor(Colors.Black).Padding(2).AlignCenter().Text("Sub Total").Bold();
                });

                foreach (var item in model.DetalleComprobantes)
                {
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).Text(text =>
                    {
                        text.Span($"{item.ProductoNombre.ToUpper()} ");
                        text.Span($"(Talle {item.Talle})").FontSize(7);
                    });
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text($"{item.Cantidad}");
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text($"{item.Precio.ToString("N0", culturaArg)}");
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text($"{item.SubTotal.ToString("N0", culturaArg)}");
                }

                if (model.Envio != null && model.Envio.Monto > 0)
                {
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).Text("COSTO DE ENVIO");
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text("1");
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text($"{model.Envio.Monto.ToString("N0", culturaArg)}");
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(2).AlignRight().Text($"{model.Envio.Monto.ToString("N0", culturaArg)}");
                }
            });

            // Régimen de Transparencia Fiscal 
            decimal ivaContenido = model.Total * 0.17355m;
            col.Item().PaddingTop(20).Width(260).Border(1).BorderColor(Colors.Black).Padding(3).Column(tf =>
            {
                tf.Item().Text("RÉGIMEN DE TRANSPARENCIA FISCAL AL CONSUMIDOR (LEY 27.743)").Bold().FontSize(6.5f).Underline();
                tf.Item().Text(t =>
                {
                    t.Span("IVA CONTENIDO: ").Bold().FontSize(7);
                    t.Span($"$ {ivaContenido:N2}").FontSize(7);
                });
                tf.Item().Text(t =>
                {
                    t.Span("OTROS IMPUESTOS NACIONALES INDIRECTOS: ").Bold().FontSize(7);
                    t.Span("$ 0,00").FontSize(7);
                });
            });
        });
    }

    private static void BuildFooter(IContainer container, ComprobanteGetViewModel model)
    {
        container.Column(col =>
        {
            col.Item().Border(1).BorderColor(Colors.Black).Padding(5).Row(row =>
            {
                row.ConstantItem(70).Height(70).Background(Colors.Grey.Lighten3).AlignCenter().AlignMiddle().Text("QR ARCA").FontSize(8).Bold();

                row.RelativeItem().PaddingLeft(10).AlignBottom().Column(c =>
                {
                    c.Item().Text($"FECHA VTO: {model.Fecha}").Bold().FontSize(8);
                    c.Item().Text($"CAE: 73{model.Id:D12}").Bold().FontSize(8); // CAE generado a partir del ID de la compra
                });

                row.RelativeItem().AlignRight().AlignBottom().Column(c =>
                {
                    c.Item().Row(r =>
                    {
                        r.RelativeItem().Text("SUBTOTAL:").Bold().AlignRight();
                        r.ConstantItem(80).Text($"$ {model.Total.ToString("N2", culturaArg)}").AlignRight();
                    });
                    c.Item().Row(r =>
                    {
                        r.RelativeItem().Text("TOTAL:").Bold().FontSize(11).AlignRight();
                        r.ConstantItem(80).Text($"$ {model.Total.ToString("N2", culturaArg)}").Bold().FontSize(11).AlignRight();
                    });
                });
            });

            col.Item().PaddingTop(4).AlignCenter().Text("ESTA ES UNA REPRESENTACIÓN GRÁFICA DE UN COMPROBANTE FICTICIO EMITIDO A MODO DE SIMULACIÓN.").FontSize(7).Italic().FontColor(Colors.Grey.Darken1);
        });
    }
}