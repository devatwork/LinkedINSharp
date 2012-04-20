using System;
using System.Net;
using LinkedINSharp.Model.OAuth;
using RestSharp;
using RestSharp.Authenticators;

namespace LinkedINSharp
{
	/// <summary>
	/// REST client for the LinkedIN API.
	/// </summary>
	public partial class LinkedINRestClient
	{
		#region Constants
		/// <summary>
		/// Defines the base URL.
		/// </summary>
		private const string BaseUrl = "http://api.linkedin.com/v1";
		#endregion
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
		/// <param name="accessToken">The <see cref="AccessToken"/> of the currently authenticated user.</param>
		/// <exception cref="ArgumentNullException">Thrown when either <paramref name="consumerKey"/>, <paramref name="consumerSecret"/> or <paramref name="accessToken"/> is null or empty.</exception>
		public LinkedINRestClient( string consumerKey, string consumerSecret, AccessToken accessToken ) : this( consumerKey, consumerSecret )
		{
			// validate arguments
			if ( accessToken == null )
				throw new ArgumentNullException( "accessToken" );

			// set values
			this.accessToken = accessToken;
		}
		#endregion
		#region ExecuteRequest Mehtods
		/// <summary>
		/// Makes a <paramref name="request"/> to the <paramref name="client"/>.
		/// </summary>
		/// <param name="client">The <see cref="IRestClient"/> on which to execute the <paramref name="request"/>.</param>
		/// <param name="request">The <see cref="IRestRequest"/> which to execute on the <paramref name="client"/>.</param>
		/// <param name="expectedStatusCode">The exepected status code of the request, default is <seealso cref="HttpStatusCode.OK"/>.</param>
		/// <returns>Returns the resulting <see cref="IRestResponse"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="client"/> or <paramref name="request"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the actual response code did not match the <paramref name="expectedStatusCode"/>.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		protected IRestResponse ExecuteRequest( IRestClient client, IRestRequest request, HttpStatusCode expectedStatusCode = HttpStatusCode.OK )
		{
			// validate arguments
			if ( client == null )
				throw new ArgumentNullException( "client" );
			if ( request == null )
				throw new ArgumentNullException( "request" );

			// execute the request
			var response = client.Execute( request );

			// make sure the exected status code is returned
			VerifyResponse( response, expectedStatusCode );

			// return the response
			return response;
		}
		/// <summary>
		/// Executes the given <paramref name="request"/> and maps the response to <typeparamref name="TModel"/>.
		/// </summary>
		/// <typeparam name="TModel">The type of the model, must have an parameterless constructors.</typeparam>
		/// <param name="request">The <see cref="IRestRequest"/> which to execute.</param>
		/// <param name="expectedStatusCode">The exepected status code of the request, default is <seealso cref="HttpStatusCode.OK"/>.</param>
		/// <returns>Returns the mapped <typeparamref name="TModel"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the actual response code did not match the <paramref name="expectedStatusCode"/>.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		protected TModel ExecuteRequest< TModel >( IRestRequest request, HttpStatusCode expectedStatusCode = HttpStatusCode.OK ) where TModel : new()
		{
			// validate arguments
			if ( request == null )
				throw new ArgumentNullException( "request" );

			// make sure an token is set
			if ( accessToken == null )
				throw new LinkedINUnauthorizedException();

			// create the client
			var client = new RestClient
			             	{
			             		BaseUrl = BaseUrl,
			             		Authenticator = OAuth1Authenticator.ForProtectedResource( consumerKey, consumerSecret, accessToken.Token, accessToken.Secret )
			             	};

			// execute the request
			var response = client.Execute< TModel >( request );

			// make sure the exected status code is returned
			VerifyResponse( response, expectedStatusCode );

			// return the response
			return response.Data;
		}
		/// <summary>
		/// Verifies whether given <paramref name="response"/> is as expected.
		/// </summary>
		/// <param name="response">The <see cref="IRestResponse"/> which to verify.</param>
		/// <param name="expectedStatusCode">The exepected status code of the request, default is <seealso cref="HttpStatusCode.OK"/>.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="response"/> is null.</exception>
		protected static void VerifyResponse( IRestResponse response, HttpStatusCode expectedStatusCode = HttpStatusCode.OK )
		{
			// validate arguments
			if ( response == null )
				throw new ArgumentNullException( "response" );

			// check if the user was not authorized to make the request
			if ( response.StatusCode == HttpStatusCode.Unauthorized && expectedStatusCode != HttpStatusCode.Unauthorized )
				throw new LinkedINUnauthorizedException();

			// check if the actuel status code is not the expected status code
			if ( response.StatusCode != expectedStatusCode )
				throw new LinkedINHttpResponseException( expectedStatusCode, response.StatusCode, response.ErrorMessage, response.ErrorException );
		}
		#endregion
		#region Private Fields
		private readonly AccessToken accessToken;
		private readonly string consumerKey;
		private readonly string consumerSecret;
		#endregion
	}
}