namespace Unihub.Dominio.Entidades
{
    public class Nota
    {
        public int Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public decimal Peso { get; private set; }

        public Atividade Atividade { get; set; }

        public Nota(decimal valor, DateTime dataAvaliacao, decimal peso)
        {
            Validar(valor, dataAvaliacao, peso);
            Atualizar(valor, dataAvaliacao, peso);
        }

        public Nota(int id, decimal valor, DateTime dataAvaliacao, decimal peso)
        {
            if (id <= 0)
                throw new ArgumentException("O ID da nota deve ser maior que zero.", nameof(id));

            Id = id;

            Validar(valor, dataAvaliacao, peso);
            Atualizar(valor, dataAvaliacao, peso);
        }

        private void Validar(decimal valor, DateTime dataAvaliacao, decimal peso)
        {
            if (valor < 0)
                throw new ArgumentException("O valor da nota não pode ser negativo.", nameof(valor));

            if (dataAvaliacao == default)
                throw new ArgumentException("A data da avaliação é inválida.", nameof(dataAvaliacao));

            if (peso < 0)
                throw new ArgumentException("O peso da nota não deve ser um valor negativo.", nameof(peso));
        }

        private void Atualizar(decimal valor, DateTime dataAvaliacao, decimal peso)
        {
            Valor = valor;
            DataAvaliacao = dataAvaliacao;
            Peso = peso;
        }
    }
}
