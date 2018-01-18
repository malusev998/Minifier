using System;
using System.Diagnostics.CodeAnalysis;

namespace Minifier
{
    public class ArgumentNotSuppliedException : Exception
    {
        public override string Message { get; } = "Argument is not supplied";

        public ArgumentNotSuppliedException()
        {
            
        }
        public ArgumentNotSuppliedException(string message):this()
        {
            this.Message = message;
        }
        public override string ToString()
        {
            return $"{Message}";
        }
    }
}