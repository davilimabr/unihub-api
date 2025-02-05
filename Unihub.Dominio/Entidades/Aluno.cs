﻿namespace Unihub.Dominio.Entidades
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Matricula { get; private set; }
        public string Senha { get; private set; }

        public ICollection<Falta> Faltas { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
        public ICollection<AlunosDisciplina> AlunosDisciplinas { get; set; }

        public Aluno(string nome, string email, string matricula, string senha)
        {
            Validar(nome, email, matricula, senha);
            Atualizar(nome, email, matricula, senha);
        }

        public Aluno(int id, string nome, string email, string matricula, string senha)
        {
            if (id <= 0)
                throw new ArgumentException("O ID do aluno deve ser maior que zero.", nameof(id));

            Id = id;
            Validar(nome, email, matricula, senha);
            Atualizar(nome, email, matricula, senha);
        }

        private void Validar(string nome, string email, string matricula, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do aluno não pode ser vazio ou nulo.", nameof(nome));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail do aluno não pode ser vazio ou nulo.", nameof(email));

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha do aluno não pode ser vazia ou nula.", nameof(senha));

            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("A Matricula do aluno não pode ser vazia ou nula.", nameof(senha));
        }

        private void Atualizar(string nome, string email, string matricula, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Matricula = matricula;
        }
    }
}
