namespace LXF.Web.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public required string Descripcion { get; set; }
    }

    public class CategoriaPutViewModel : CategoriaViewModel
    {
        public int Id { get; set; }
    }

    public class CategoriaGetViewModel : ViewModelBase
    {
        public string Descripcion { get; init; }
    }
}
