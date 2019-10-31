using System;

namespace ClienteApi.Models.Exceptions
{
    public class AtributoInvalidoException : Exception
    {
        public AtributoInvalidoException(string message) : base(message) { }
    }
}
