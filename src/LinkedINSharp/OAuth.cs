using System;
using LinkedINSharp.Model.OAuth;
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
		#region OAuth Methods
		/// <summary>
		/// Requests authorization of your application by first sending the RequestToken request and then generate an LinkedIN URL to which users can be redirected. This is the first stage of OAuth.
		/// </summary>
		/// <param name="callbackUri">The <see cref="Uri"/> to which the user is redirected when returning from the LinkedIN authorization screen.</param>
		/// <param name="token">The <see cref="RequestToken"/>. Keep this somewhere safely stored with the user's session. You will need the provide this later in method <see cref="ExchangeCodeForAccessToken"/>.</param>
		/// <returns>Returns the LinkedIN authorization <see cref="Uri"/> to which users must be redirected in order give access to your application.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="callbackUri"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when LinkedIN did not respond properly while requesting the request token.</exception>
		public Uri RequestAuthorizationToken( Uri callbackUri, out RequestToken token )
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
			var requestToken = requestTokenResponseParameters[ "oauth_token" ];
			var requestSecret = requestTokenResponseParameters[ "oauth_token_secret" ];
			token = new RequestToken( requestToken, requestSecret );

			// build the redirect uri
			requestTokenRequest = new RestRequest( "authenticate?oauth_token=" + requestToken );
			return client.BuildUri( requestTokenRequest );
		}
		/// <summary>
		/// Exchanges the request code for an access token.This is the second stage of OAuth.
		/// </summary>
		/// <remarks>
		/// Make sure you call <see cref="RequestAuthorizationToken"/> first.
		/// </remarks>
		/// <param name="requestUri">The <see cref="Uri"/> of the request </param>
		/// <param name="requestToken">The request secret, gained when the call to <see cref="RequestAuthorizationToken"/> was made.</param>
		/// <returns>The <see cref="AccessToken"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="requestUri"/> or <paramref name="requestToken"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when LinkedIN did not respond properly while requesting the access token.</exception>
		public AccessToken ExchangeCodeForAccessToken( Uri requestUri, RequestToken requestToken )
		{
			// validate arguments
			if ( requestUri == null )
				throw new ArgumentNullException( "requestUri" );
			if ( requestToken == null )
				throw new ArgumentNullException( "requestToken" );

			// extract the token and verifier from the 
			var requestTokenQueryParameters = HttpUtility.ParseQueryString( requestUri.Query );
			var recievedRequestToken = requestTokenQueryParameters[ "oauth_token" ];
			var requestVerifier = requestTokenQueryParameters[ "oauth_verifier" ];

			// make sure the recievedRequestToken and the given request token are the same
			if ( !string.Equals( recievedRequestToken, requestToken.Token ) )
				throw new ArgumentException( "The given request token did not match the received request token", "requestToken" );

			// create the client
			var client = new RestClient
			             	{
			             		BaseUrl = BaseUrl,
			             		Authenticator = OAuth1Authenticator.ForAccessToken( consumerKey, consumerSecret, requestToken.Token, requestToken.Secret, requestVerifier )
			             	};

			// create the request
			var requestAccessTokenRequest = new RestRequest( "accessToken" );

			// execute the request
			var requestActionTokenResponse = ExecuteRequest( client, requestAccessTokenRequest );

			// extract the token and secret from the response query string
			var requestActionTokenResponseParameters = HttpUtility.ParseQueryString( requestActionTokenResponse.Content );
			return new AccessToken( requestActionTokenResponseParameters[ "oauth_token" ], requestActionTokenResponseParameters[ "oauth_token_secret" ] );
		}
		#endregion
	}
}