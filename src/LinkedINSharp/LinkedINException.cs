using System;
using System.Runtime.Serialization;

namespace LinkedINSharp
{
	/// <summary>
	/// Base class for all the LinkedIN exceptions.
	/// </summary>
	[Serializable]
	public class LinkedINException : Exception
	{
		#region Constructors
		/// <summary>
		/// Constructs an empty LinkedIN exception.
		/// </summary>
		public LinkedINException()
		{
		}
		/// <summary>
		/// Constructs a LinkedIN exception with the given <paramref name="message"/>.
		/// </summary>
		/// <param name="message">The message descriving the cause of this exception.</param>
		public LinkedINException( string message ) : base( message )
		{
		}
		/// <summary>
		/// Constructs a LinkedIN exception with the given <paramref name="message"/>.
		/// </summary>
		/// <param name="message">The message descriving the cause of this exception.</param>
		/// <param name="inner">The inner <see cref="Exception"/>.</param>
		public LinkedINException( string message, Exception inner ) : base( message, inner )
		{
		}
		/// <summary>
		/// Serialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LinkedINException( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
		}
		#endregion
	}
}