namespace unihub_api.Dominio.Entidades
{
    public class Professor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public ICollection<Disciplina> Disciplinas { get; set; }

        public Professor(string nome, string email)
        {
            Validar(nome, email);
            Atualizar(nome, email);
        }

        public Professor(int id, string nome, string email)
        {
            if (id <= 0)
                throw new ArgumentException("O ID do professor deve ser maior que zero.", nameof(id));

            Id = id;
            Validar(nome, email);
            Atualizar(nome, email);
        }

        private void Validar(string nome, string email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do professor não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail do professor não pode ser vazio ou nulo.", nameof(email));
        }

        private void Atualizar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
