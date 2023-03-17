using System;

namespace GoogleAPI_Library.Exceptions
{
    /// <summary>
    /// Represents errors that occur during setup Google Credential
    /// </summary>
    [Serializable]
    public class CredentialException : Exception
    {
        public CredentialException() { }
        public CredentialException(string message) : base(message) { }
        public CredentialException(string message, Exception inner) : base(message, inner) { }
        protected CredentialException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
