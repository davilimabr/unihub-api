using Unihub.Dominio.Entidades;

namespace unihub_api.Dominio.Entidades
{
    public class Disciplina
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Sala { get; private set; }
        public int TotalHoras { get; private set; }

        public int ProfessorId { get; private set; }
        public ICollection<AulasNaSemana> AulasNaSemanas { get;  set; }
        public ICollection<Atividade> Atividades { get;  set; }
        public ICollection<AlunosDisciplina> AlunosDisciplinas { get;  set; }
        public Professor Professor { get;  set; }

        public Disciplina(
            int professorId,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras)
        {
            Validar(professorId, nome, codigo, descricao, sala, totalHoras);
            Atualizar(professorId, nome, codigo, descricao, sala, totalHoras);
        }

        public Disciplina(
            int id,
            int professorId,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras)
        {
            if (id <= 0)
                throw new ArgumentException("O ID da disciplina deve ser maior que zero.", nameof(id));

            Id = id;

            Validar(professorId, nome, codigo, descricao, sala, totalHoras);
            Atualizar(professorId, nome, codigo, descricao, sala, totalHoras);
        }

        private void Validar(
            int professorId,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras)
        {
            if (professorId <= 0)
                throw new ArgumentException("O ID do professor deve ser maior que zero.", nameof(professorId));

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da disciplina não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("O código da disciplina não pode ser vazio ou nulo.", nameof(codigo));

            if (string.IsNullOrWhiteSpace(sala))
                throw new ArgumentException("A sala não pode ser vazia ou nula.", nameof(sala));

            if (totalHoras < 0)
                throw new ArgumentException("O total de horas não pode ser negativo.", nameof(totalHoras));
        }

        private void Atualizar(
            int professorId,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras)
        {
            ProfessorId = professorId;
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Sala = sala;
            TotalHoras = totalHoras;
        }
    }
}
