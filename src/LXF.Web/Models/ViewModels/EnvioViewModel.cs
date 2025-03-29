namespace LXF.Web.Models.ViewModels
{
    public class EnvioViewModel : ViewModelBase
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public int LocalidadId { get; set; }
        public int Comprobante_Id { get; set; }
        public string ComprobanteStr { get; set; }
        public string LocalidadeStr { get; set; }
    }
}
