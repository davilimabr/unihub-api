//adicionar crud falta
//Mensagem que o Guilherme mandou no zap

namespace Unihub.Dominio.Entidades
{
    public class Disciplina
    {
        public int Id { get; private set; }
        public string Professor { get; private set; }
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Sala { get; private set; }
        public int Periodo { get; private set; }
        public bool Obrigatoria { get; private set; }
        public int TotalHoras { get; private set; }

        public ICollection<Atividade> Atividades { get; set; }
        public ICollection<AlunosDisciplina> AlunosDisciplinas { get; set; }
        public ICollection<Falta> Faltas { get; set; }

        public Disciplina(
            string professor,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras,
            int periodo,
            bool obrigatoria)
        {
            Validar(professor, nome, codigo, descricao, sala, totalHoras, periodo, obrigatoria);
            Atualizar(professor, nome, codigo, descricao, sala, totalHoras, periodo, obrigatoria);
        }

        public Disciplina(
            int id,
            string professor,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras,
            int periodo,
            bool obrigatoria)
        {
            if (id <= 0)
                throw new ArgumentException("O ID da disciplina deve ser maior que zero.", nameof(id));

            Id = id;

            Validar(professor, nome, codigo, descricao, sala, totalHoras, periodo, obrigatoria);
            Atualizar(professor, nome, codigo, descricao, sala, totalHoras, periodo, obrigatoria);
        }

        private void Validar(
            string professor,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras,
            int periodo,
            bool obrigatoria)
        {
            if (string.IsNullOrWhiteSpace(professor))
                throw new ArgumentException("O nome do professor não pode ser vazio ou nulo.", nameof(professor));

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da disciplina não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("O código da disciplina não pode ser vazio ou nulo.", nameof(codigo));

            if (string.IsNullOrWhiteSpace(sala))
                throw new ArgumentException("A sala não pode ser vazia ou nula.", nameof(sala));

            if (descricao.Length > 500)
                throw new ArgumentException("A descrição deve possuir menos de 500 caracteres.", nameof(descricao));

            if (totalHoras < 0)
                throw new ArgumentException("O total de horas não pode ser negativo.", nameof(totalHoras));
        }

        private void Atualizar(
            string professor,
            string nome,
            string codigo,
            string descricao,
            string sala,
            int totalHoras,
            int periodo,
            bool obrigatoria)
        {
            Professor = professor;
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Sala = sala;
            TotalHoras = totalHoras;
            Periodo = periodo;
            Obrigatoria = obrigatoria;
        }
    }
}
