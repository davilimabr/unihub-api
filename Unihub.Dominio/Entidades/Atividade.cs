namespace unihub_api.Dominio.Entidades
{
    public class Atividade
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public string Status { get; private set; }

        public int AlunoId { get; private set; }
        public int DisciplinaId { get; private set; }
        public int? NotaId { get; private set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina{ get; set; }
        public Nota? Nota { get; set; }

        public Atividade(int alunoId, int disciplinaId, int? notaId, string nome, string descricao, DateTime dataEntrega, string status)
        {
            Validar(alunoId, disciplinaId, notaId, nome, descricao, dataEntrega, status);
            Atualizar(alunoId, disciplinaId, notaId, nome, descricao, dataEntrega, status);
        }

        public Atividade(int id, int alunoId, int disciplinaId, int? notaId, string nome, string descricao, DateTime dataEntrega, string status)
        {
            if (id <= 0)
                throw new ArgumentException("O ID de Atividades deve ser maior que zero.", nameof(id));

            Id = id;
            Validar(alunoId, disciplinaId, notaId, nome, descricao, dataEntrega, status);
            Atualizar(alunoId, disciplinaId, notaId, nome, descricao, dataEntrega, status);
        }

        private void Validar(int alunoId, int disciplinaId, int? notaId, string nome, string descricao, DateTime dataEntrega, string status)
        {
            if (alunoId <= 0)
                throw new ArgumentException("O ID do aluno deve ser maior que zero.", nameof(alunoId));

            if (disciplinaId <= 0)
                throw new ArgumentException("O ID da disciplina deve ser maior que zero.", nameof(alunoId));

            if (notaId != null && notaId <= 0)
                throw new ArgumentException("O ID da nota deve ser maior que zero.", nameof(alunoId));

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da atividade não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição da atividade não pode ser vazia ou nula.", nameof(descricao));

            if (dataEntrega == default)
                throw new ArgumentException("A data de entrega é inválida.", nameof(dataEntrega));

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("O status da atividade não pode ser vazio ou nulo.", nameof(status));
        }

        private void Atualizar(int alunoId, int disciplinaId, int? notaId, string nome, string descricao, DateTime dataEntrega, string status)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
            NotaId = notaId;
            Nome = nome;
            Descricao = descricao;
            DataEntrega = dataEntrega;
            Status = status;
        }
    }
}
