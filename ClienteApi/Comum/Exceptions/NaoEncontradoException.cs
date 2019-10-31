using System;

namespace ClienteApi.Comum.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string message) : base(message) { }
    }
}
