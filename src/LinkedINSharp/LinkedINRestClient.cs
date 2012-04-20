using System;
using System.Net;
using RestSharp;

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
			if ( response.StatusCode != expectedStatusCode )
				throw new LinkedINHttpResponseException( expectedStatusCode, response.StatusCode, response.ErrorMessage, response.ErrorException );

			// return the response
			return response;
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