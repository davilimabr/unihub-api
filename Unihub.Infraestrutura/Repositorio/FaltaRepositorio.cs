using Unihub.Dominio.Entidades;
using Unihub.Dominio.Interfaces;
using Unihub.Infraestrutura.Contexto;

namespace Unihub.Infraestrutura.Repositorio
{
    public class FaltaRepositorio : IFaltaRepositorio
    {
        private readonly AppDbContext _context;

        public FaltaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Falta> RegistrarFalta(Falta falta)
        {
            _context.Falta.Add(falta);
            await _context.SaveChangesAsync();
            return falta;
        }
    }
}
