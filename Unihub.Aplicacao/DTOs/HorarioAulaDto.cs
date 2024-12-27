using Unihub.Dominio.Comum.Enumeradores;

namespace Unihub.Aplicacao.DTOs
{
    public class HorarioAulaDto
    {
        public int Id { get; set; }
        public int HoraInicio { get; set; }
        public int HoraTermino { get; set; }
        public DiasDaSemana Dia { get; set; }
    }
}
