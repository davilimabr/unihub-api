using unihub_api.Dominio.Entidades;

namespace Unihub.Dominio.Entidades
{
    public class AulasNaSemana
    {
        public int Id { get; private set; }
        public int DisciplinaId { get; private set; }
        public int HorarioAulaId { get; private set; }
        public Disciplina Disciplina { get; set; }
        public HorarioAula HorarioAula { get; set; }

        public AulasNaSemana(int id, int disciplinaId, int horarioAulaId)
        {
            Id = id;
            DisciplinaId = disciplinaId;
            HorarioAulaId = horarioAulaId;
        }

        public AulasNaSemana(int disciplinaId, int horarioAulaId)
        {
            DisciplinaId = disciplinaId;
            HorarioAulaId = horarioAulaId;
        }
    }
}
