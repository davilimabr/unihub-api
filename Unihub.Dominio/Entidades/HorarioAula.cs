using Unihub.Dominio.Comum.Enumeradores;

namespace Unihub.Dominio.Entidades
{
    public class HorarioAula
    {
        public int Id { get; private set; }
        public int HoraInicio { get; private set; }
        public int HoraTermino { get; private set; }
        public DiasDaSemana Dia { get; private set; }

        public ICollection<AulasNaSemana> AulasNaSemanas { get; set; }
        public ICollection<Falta> Faltas { get; set; }

        public HorarioAula(int horaInicio, int horaTermino, DiasDaSemana dia)
        {
            Validar(horaInicio, horaTermino, dia);
            Atualizar(horaInicio, horaTermino, dia);
        }

        public HorarioAula(int id, int horaInicio, int horaTermino, DiasDaSemana dia)
        {
            if (id <= 0)
                throw new ArgumentException("O ID do horário de aula deve ser maior que zero.", nameof(id));

            Id = id;

            Validar(horaInicio, horaTermino, dia);
            Atualizar(horaInicio, horaTermino, dia);
        }

        private void Validar(int horaInicio, int horaTermino, DiasDaSemana dia)
        {
            if (horaInicio < 0 || horaInicio > 23)
                throw new ArgumentException("A hora de início deve estar entre 0 e 23.", nameof(horaInicio));

            if (horaTermino <= horaInicio || horaTermino > 24)
                throw new ArgumentException(
                    "A hora de término deve ser maior que a hora de início e no máximo 24.",
                    nameof(horaTermino)
                );

            if (dia == DiasDaSemana.Domingo)
                throw new ArgumentException("Não há aulas aos domingos.", nameof(dia));
        }

        private void Atualizar(int horaInicio, int horaTermino, DiasDaSemana dia)
        {
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Dia = dia;
        }
    }
}
