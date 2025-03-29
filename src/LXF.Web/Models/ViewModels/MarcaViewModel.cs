namespace LXF.Web.Models.ViewModels
{
    public class MarcaViewModel
    {
        public required string Descripcion { get; set; }
    }

    public class MarcaPutViewModel : MarcaViewModel
    {
        public int Id { get; set; }
    }

    public class MarcaGetViewModel : ViewModelBase
    {
        public string Descripcion { get; init; }
    }
}
