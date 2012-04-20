using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Contrib;

namespace LinkedINSharp
{
	/// <summary>
	/// Implements the OAuth 1.1 part of the LinkedIN rest client.
	/// </summary>
	/// <seealso href="https://developer.linkedin.com/documents/authentication"/>
	public partial class LinkedINRestClient
	{
		#region Constants
		/// <summary>
		/// Defines the base URL for all the OAuth
		/// </summary>
		private const string BaseUrl = "https://api.linkedin.com/uas/oauth";
		#endregion
		#region Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="callbackUri">The <see cref="Uri"/> to which the user is redirected when returning from the LinkedIN authorization screen.</param>
		/// <param name="requestTokenSecret">The secret of the request token. Keep this somewhere safely stored with the user's session. You will need the provide this later in method TODO.</param>
		/// <returns>Returns the LinkedIN authorization <see cref="Uri"/> to which users must be redirected in order give access to your application.</returns>
		/// <exception cref="ArgumentNullException">Thrown whe <paramref name="callbackUri"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when LinkedIN did not respond properly while requesting the request token.</exception>
		public Uri RequestAuthorizationToken( Uri callbackUri, out string requestTokenSecret )
		{
			// validate arguments
			if ( callbackUri == null )
				throw new ArgumentNullException( "callbackUri" );

			// create the client
			var client = new RestClient
			             	{
			             		BaseUrl = BaseUrl,
			             		Authenticator = OAuth1Authenticator.ForRequestToken( consumerKey, consumerSecret, callbackUri.ToString() )
			             	};

			// create the request
			var request = new RestRequest( "requestToken" );

			// execute the request
			var response = ExecuteRequest( client, request );

			// extract the token from the query string
			var queryString = HttpUtility.ParseQueryString( response.Content );
			var oauthToken = queryString[ "oauth_token" ];
			requestTokenSecret = queryString[ "oauth_token_secret" ];

			// build the redirect uri
			request = new RestRequest( "authenticate?oauth_token=" + oauthToken );
			return client.BuildUri( request );
		}
		#endregion
	}
}