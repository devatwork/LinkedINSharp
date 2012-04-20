using System;

namespace LinkedINSharp.Model.OAuth
{
	/// <summary>
	/// Holds an access token. You need this object to make authorized requests.
	/// </summary>
	[Serializable]
	public class AccessToken : OAuthToken
	{
		#region Constructors
		/// <summary>
		/// Constructs an access token.
		/// </summary>
		/// <param name="token">The token.</param>
		/// <param name="secret">The secret.</param>
		public AccessToken( string token, string secret ) : base( token, secret )
		{
		}
		#endregion
	}
}