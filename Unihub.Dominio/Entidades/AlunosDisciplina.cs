namespace Unihub.Dominio.Entidades
{
    public class AlunosDisciplina
    {
        public int Id { get; private set; }
        public int AlunoId { get; private set; }
        public int DisciplinaId { get; private set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }

        public AlunosDisciplina(int id, int alunoId, int disciplinaId)
        {
            Id = id;
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }

        public AlunosDisciplina(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }
    }
}
