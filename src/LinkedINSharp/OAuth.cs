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
		/// Requests authorization of your application by first sending the RequestToken request and then generate an LinkedIN URL to which users can be redirected. This is the first stage of OAuth.
		/// </summary>
		/// <param name="callbackUri">The <see cref="Uri"/> to which the user is redirected when returning from the LinkedIN authorization screen.</param>
		/// <param name="requestSecret">The secret of the request token. Keep this somewhere safely stored with the user's session. You will need the provide this later in method <see cref="ExchangeCodeForAccessToken"/>.</param>
		/// <returns>Returns the LinkedIN authorization <see cref="Uri"/> to which users must be redirected in order give access to your application.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="callbackUri"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when LinkedIN did not respond properly while requesting the request token.</exception>
		public Uri RequestAuthorizationToken( Uri callbackUri, out string requestSecret )
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
			var requestTokenRequest = new RestRequest( "requestToken" );

			// execute the request
			var requestTokenResponse = ExecuteRequest( client, requestTokenRequest );

			// extract the token from the query string
			var requestTokenResponseParameters = HttpUtility.ParseQueryString( requestTokenResponse.Content );
			var oauthToken = requestTokenResponseParameters[ "oauth_token" ];
			requestSecret = requestTokenResponseParameters[ "oauth_token_secret" ];

			// build the redirect uri
			requestTokenRequest = new RestRequest( "authenticate?oauth_token=" + oauthToken );
			return client.BuildUri( requestTokenRequest );
		}
		/// <summary>
		/// Exchanges the request code for an access token.This is the second stage of OAuth.
		/// </summary>
		/// <remarks>
		/// Make sure you call <see cref="RequestAuthorizationToken"/> first.
		/// </remarks>
		/// <param name="requestUri">The <see cref="Uri"/> of the request </param>
		/// <param name="requestSecret">The request secret, gained when the call to <see cref="RequestAuthorizationToken"/> was made.</param>
		/// <param name="accessToken">The access token.</param>
		/// <param name="accessSecret">The access secret.</param>
		/// <returns>Returns the original <see cref="Uri"/> from which the user came before starting the authorization flow.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="requestUri"/> or <paramref name="requestSecret"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when LinkedIN did not respond properly while requesting the access token.</exception>
		public void ExchangeCodeForAccessToken( Uri requestUri, string requestSecret, out string accessToken, out string accessSecret )
		{
			// validate arguments
			if ( requestUri == null )
				throw new ArgumentNullException( "requestUri" );
			if ( string.IsNullOrEmpty( requestSecret ) )
				throw new ArgumentNullException( "requestSecret" );

			// extract the token and verifier from the 
			var requestTokenQueryParameters = HttpUtility.ParseQueryString( requestUri.Query );
			var requestToken = requestTokenQueryParameters[ "oauth_token" ];
			var requestVerifier = requestTokenQueryParameters[ "oauth_verifier" ];

			// create the client
			var client = new RestClient
			             	{
			             		BaseUrl = BaseUrl,
			             		Authenticator = OAuth1Authenticator.ForAccessToken( consumerKey, consumerSecret, requestToken, requestSecret, requestVerifier )
			             	};

			// create the request
			var requestAccessTokenRequest = new RestRequest( "accessToken" );

			// execute the request
			var requestActionTokenResponse = ExecuteRequest( client, requestAccessTokenRequest );

			// extract the token and secret from the response query string
			var requestActionTokenResponseParameters = HttpUtility.ParseQueryString( requestActionTokenResponse.Content );
			accessToken = requestActionTokenResponseParameters[ "oauth_token" ];
			accessSecret = requestActionTokenResponseParameters[ "oauth_token_secret" ];
		}
		#endregion
	}
}