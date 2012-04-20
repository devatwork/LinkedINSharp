using System;

namespace LinkedINSharp.Model.OAuth
{
	/// <summary>
	/// Holds a request token. You need this object when making the authorization, <see cref="LinkedINRestClient.RequestAuthorizationToken"/> and <see cref="LinkedINRestClient.ExchangeCodeForAccessToken"/> for details.
	/// </summary>
	[Serializable]
	public class RequestToken : OAuthToken
	{
		#region Constructors
		/// <summary>
		/// Constructs a request token.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="secret">The secret.</param>
		public RequestToken( string token, string secret ) : base( token, secret )
		{
		}
		#endregion
	}
}