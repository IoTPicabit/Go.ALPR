using System.Threading.Tasks;
using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public interface IContactoService
    {
        Task<IPagedList<ContactoDto>> ObtenerListaPaginada(
           string Nombre,
           string Email,
           bool? Habilitado,
           int pageNumber = 1,
           int pageSize = 10);
                
        bool Guardar(ContactoDto contacto);

        bool Eliminar(ContactoDto contacto);
    }
}
