using Unihub.Dominio.Entidades;

namespace Unihub.Dominio.Interfaces
{
    public interface IFaltaRepositorio
    {
        Task<Falta> RegistrarFalta(Falta falta);
    }
}
