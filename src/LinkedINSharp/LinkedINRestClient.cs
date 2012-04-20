using System;

namespace LinkedINSharp
{
	/// <summary>
	/// REST client for the LinkedIN API.
	/// </summary>
	public partial class LinkedINRestClient
	{
		#region Constructors
		/// <summary>
		/// Constructs the LinkedIN REST client for anonymous usage. Tipically used when authenticating the user.
		/// </summary>
		/// <param name="consumerKey">The key of the consumer.</param>
		/// <param name="consumerSecret">The consumer secret.</param>
		/// <exception cref="ArgumentNullException">Thrown when either <paramref name="consumerKey"/> or <paramref name="consumerSecret"/> is null or empty.</exception>
		public LinkedINRestClient( string consumerKey, string consumerSecret )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( consumerKey ) )
				throw new ArgumentNullException( "consumerKey" );
			if ( string.IsNullOrEmpty( consumerSecret ) )
				throw new ArgumentNullException( "consumerSecret" );

			// set values
			this.consumerKey = consumerKey;
			this.consumerSecret = consumerSecret;
		}
		/// <summary>
		/// Constructs the LinkedIN REST client.
		/// </summary>
		/// <param name="consumerKey">The key of the consumer.</param>
		/// <param name="consumerSecret">The consumer secret.</param>
		/// <param name="accessToken">The access token of the currently authenticated user.</param>
		/// <param name="accessSecret">The access secret of the currently authenticated user.</param>
		/// <exception cref="ArgumentNullException">Thrown when either <paramref name="consumerKey"/>, <paramref name="consumerSecret"/>, <paramref name="accessToken"/> or <paramref name="accessSecret"/> is null or empty.</exception>
		public LinkedINRestClient( string consumerKey, string consumerSecret, string accessToken, string accessSecret ) : this( consumerKey, consumerSecret )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( accessToken ) )
				throw new ArgumentNullException( "accessToken" );
			if ( string.IsNullOrEmpty( accessSecret ) )
				throw new ArgumentNullException( "accessSecret" );

			// set values
			this.accessToken = accessToken;
			this.accessSecret = accessSecret;
		}
		#endregion
		#region Private Fields
		private readonly string accessSecret;
		private readonly string accessToken;
		private readonly string consumerKey;
		private readonly string consumerSecret;
		#endregion
	}
}