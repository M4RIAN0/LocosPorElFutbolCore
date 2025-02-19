using Servicio.Base;

namespace IServicio.Categoria.Dto
{
    public class CategoriaDto
    {
        public string Descripcion { get; set; }
    }

    public class CategoriaPutDto : DtoBase
    {
        public string Descripcion { get; set; }
    }

    public class CategoriaGetDto : DtoBase
    {
        public string Descripcion { get; init; }
    }
}
