using System.Runtime.Serialization;

namespace Unihub.Dominio.Comum.Excecoes
{
    public class RecursoNaoEncontradoException : Exception
    {
        public RecursoNaoEncontradoException(string? message) : base(message)
        {
        }

        public RecursoNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecursoNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
