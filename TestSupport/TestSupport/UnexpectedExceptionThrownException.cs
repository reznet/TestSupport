using System;
using System.Runtime.Serialization;

namespace TestSupport
{
    public class UnexpectedExceptionThrownException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedExceptionThrownException"/> class.
        /// </summary>
        /// <param name="message">The expected exception type.</param>
        /// <param name="actualType">The actual exception type thrown.</param>
        public UnexpectedExceptionThrownException(Type expectedType, Type actualType)
            : base(FormatMessageForTypes(expectedType, actualType))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedExceptionThrownException"/> class.
        /// </summary>
        /// <param name="message">The expected exception type.</param>
        /// <param name="actualType">The actual exception type thrown.</param>
        /// <param name="inner">The inner exception.</param>
        public UnexpectedExceptionThrownException(Type expectedType, Type actualType, Exception inner)
            : base(FormatMessageForTypes(expectedType, actualType), inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedExceptionThrownException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected UnexpectedExceptionThrownException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        private static string FormatMessageForTypes(Type expectedType, Type actualType)
        {
            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }
            if (actualType == null)
            {
                throw new ArgumentNullException("actualType");
            }

            return string.Format("Expected type '{0}' but caught '{1}'.", expectedType.Name, actualType.Name);
        }
    }
}
