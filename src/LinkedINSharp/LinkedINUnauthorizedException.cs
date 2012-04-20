using System;
using System.Runtime.Serialization;

namespace LinkedINSharp
{
	/// <summary>
	/// Thrown when an request to a protected resource was made without authenticating first.
	/// </summary>
	[Serializable]
	public class LinkedINUnauthorizedException : LinkedINException
	{
		#region Constuctor
		/// <summary>
		/// Constructs an empty LinkedINUnauthorizedException.
		/// </summary>
		public LinkedINUnauthorizedException() : base( "An request was probably made with an invalid access token. Please authenticate using LinkedINRestClient.RequestAuthorizationToken and LinkedINRestClient.ExchangeCodeForAccessToken." )
		{
		}
		/// <summary>
		/// Serialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LinkedINUnauthorizedException( SerializationInfo info, StreamingContext context ) : base( info, context )
		{
		}
		#endregion
	}
}