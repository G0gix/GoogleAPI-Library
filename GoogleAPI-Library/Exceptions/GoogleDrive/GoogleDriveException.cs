using System;
using System.Runtime.Serialization;

namespace GoogleAPI_Library.Exceptions.GoogleDrive
{
    /// <summary>
    /// Represents errors that occur during request to google drive.
    /// </summary>
    [Serializable]
    public class GoogleDriveException : Exception
    {
        public GoogleDriveException() { }

        public GoogleDriveException(string message) : base(message) { }

        public GoogleDriveException(string message, Exception inner) : base(message, inner) { }

        protected GoogleDriveException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
