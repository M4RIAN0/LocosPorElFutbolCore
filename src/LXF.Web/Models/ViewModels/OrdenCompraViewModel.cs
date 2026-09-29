namespace LXF.Web.Models.ViewModels
{

    public class OrdenCompraViewModel
    {
        public string UserId { get; set; }
        public IEnumerable<DetalleOrdenCompraViewModel> DetalleOrdenCompras { get; set; }
        public decimal Total { get; set; }
        public string? Nombre { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Fecha { get; set; }
        public string Status { get; set; }
        public int PersonaClienteId { get; set; }
        public int CarroId { get; set; }

        //Seccion Facturacion y Envio
        public FacturaViewModel Factura { get; set; }
        public EnvioViewModel Envio { get; set; }
    }

    public class OrdenCompraGetViewModel : ViewModelBase
    {
        public string UserId { get; init; }
        public IEnumerable<DetalleOrdenCompraGetViewModel> DetalleOrdenCompras { get; init; }
        public decimal Total { get; init; }
        public string Nombre { get; init; }
        public string Celular { get; init; }
        public string Email { get; init; }
        public string Fecha { get; init; }

        //Seccion Facturacion y Envio
        public FacturaGetViewModel Factura { get; init; }
        public EnvioGetViewModel Envio { get; init; }
    }
}

