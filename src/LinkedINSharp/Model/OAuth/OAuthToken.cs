using System;

namespace LinkedINSharp.Model.OAuth
{
	/// <summary>
	/// Base class for OAuth tokens.
	/// </summary>
	public abstract class OAuthToken
	{
		#region Constructors
		/// <summary>
		/// Constructs an OAuth token.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="secret">The secret.</param>
		protected OAuthToken( string token, string secret )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( token ) )
				throw new ArgumentNullException( "token" );
			if ( string.IsNullOrEmpty( secret ) )
				throw new ArgumentNullException( "secret" );

			// set values
			Token = token;
			Secret = secret;
		}
		#endregion
		#region Properties
		/// <summary>
		/// Gets the request token.
		/// </summary>
		public string Token { get; private set; }
		/// <summary>
		/// Gets teh request token secret.
		/// </summary>
		public string Secret { get; private set; }
		#endregion
	}
}