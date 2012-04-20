using System;
using System.Net;
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
			var response = client.Execute( request );

			// make sure the request succeeded
			// TODO: add better error handling
			if ( response.StatusCode != HttpStatusCode.OK )
				throw new InvalidOperationException( "Could not make requestToken request succesfully" );

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