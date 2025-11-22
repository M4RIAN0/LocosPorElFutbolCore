namespace LXF.Web.Models.ViewModels
{
    public class TransactionObjectsViewModel
    {
        public OrdenComprasViewModel Orden { get; set; }
        public ComprobanteViewModel Comprobante { get; set; }
        public FacturaViewModel Factura { get; set; }
        public int CarroId { get; set; }
    }
}
