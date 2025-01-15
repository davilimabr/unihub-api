namespace Unihub.Dominio.Entidades
{
    public class Falta
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public int Horas { get; private set; }
        public string Motivo { get; private set; }
        public int AlunoId { get; private set; }
        public int DisciplinaId { get; private set; }
        public Aluno Aluno { get; private set; }
        public Disciplina Disciplina { get; private set; }

        public Falta(int horas, DateTime data, string motivo, int alunoId)
        {
            Validar(horas, data, motivo, alunoId);
            Atualizar(horas, data, motivo, alunoId);
        }

        public Falta(int id, int horas, DateTime data, string motivo, int alunoId)
        {
            if (id <= 0)
                throw new ArgumentException("O ID da falta deve ser maior que zero.", nameof(id));

            Id = id;
            Validar(horas, data, motivo, alunoId);
            Atualizar(horas, data, motivo, alunoId);
        }

        private void Validar(int horas, DateTime data, string motivo, int alunoId)
        {
            if (data == default)
                throw new ArgumentException("A data da falta é inválida.", nameof(data));

            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("O motivo da falta não pode ser vazio ou nulo.", nameof(motivo));

            if (alunoId <= 0)
                throw new ArgumentException("O ID do aluno deve ser maior que zero.", nameof(alunoId));
        }

        private void Atualizar(int horas, DateTime data, string motivo, int alunoId)
        {
            Data = data;
            Motivo = motivo;
            AlunoId = alunoId;
            Horas = horas;
        }
    }
}
