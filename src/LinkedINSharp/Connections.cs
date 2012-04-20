using System;
using System.Collections.Generic;
using LinkedINSharp.Model;
using LinkedINSharp.Model.People;
using RestSharp;

namespace LinkedINSharp
{
	/// <summary>
	/// Implements the LinkedIN connections API part for the LinkedIN rest client.
	/// </summary>
	/// <seealso href="https://developer.linkedin.com/documents/connections-api" />
	public partial class LinkedINRestClient
	{
		#region Retrieve Profile Methods
		/// <summary>
		/// Returns a list of <see cref="Connections"/> for the current member.
		/// </summary>
		/// <param name="fields">The fields which to select from the person. See LinkedIN for an list of fields.</param>
		/// <param name="start">Starting location within the result set for paginated returns. Ranges are specified with a starting index and a number of results (count) to return. The default value for this parameter is 0.</param>
		/// <param name="count">Ranges are specified with a starting index and a number of results to return. You may specify any number. Default and max page size is 500. Implement pagination to retrieve more than 500 connections.</param>
		/// <returns>Returns the <see cref="Connections"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		public Connections RetrieveCurrentMemberConnections( IEnumerable< ProfileField > fields, int start = 0, int count = 500 )
		{
			// validate arguments
			if ( fields == null )
				throw new ArgumentNullException( "fields" );

			// retrieve the profile
			return RetrieveConnections( "~", fields, start, count );
		}
		/// <summary>
		/// Returns a list of <see cref="Connections"/> for the member identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The ID of the person which to retrieve.</param>
		/// <param name="fields">The <see cref="ProfileField"/>s  which to load into the connections.</param>
		/// <param name="start">Starting location within the result set for paginated returns. Ranges are specified with a starting index and a number of results (count) to return. The default value for this parameter is 0.</param>
		/// <param name="count">Ranges are specified with a starting index and a number of results to return. You may specify any number. Default and max page size is 500. Implement pagination to retrieve more than 500 connections.</param>
		/// <returns>Returns the <see cref="Connections"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when either <paramref name="id"/> or <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		public Connections RetrieveMemberConnections( string id, IEnumerable< ProfileField > fields, int start = 0, int count = 500 )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( id ) )
				throw new ArgumentNullException( "id" );
			if ( fields == null )
				throw new ArgumentNullException( "fields" );

			// retrieve the profile
			return RetrieveConnections( "idPart=" + id, fields, start, count );
		}
		/// <summary>
		/// Returns a list of <see cref="Connections"/> for the member identified by <paramref name="idPart"/>.
		/// </summary>
		/// <param name="idPart">The identifying part.</param>
		/// <param name="fields">The <see cref="ProfileField"/>s  which to load into the connections.</param>
		/// <param name="start">Starting location within the result set for paginated returns. Ranges are specified with a starting index and a number of results (count) to return. The default value for this parameter is 0.</param>
		/// <param name="count">Ranges are specified with a starting index and a number of results to return. You may specify any number. Default and max page size is 500. Implement pagination to retrieve more than 500 connections.</param>
		/// <returns>Returns the <see cref="Connections"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="idPart"/> or <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		protected Connections RetrieveConnections( string idPart, IEnumerable< ProfileField > fields, int start, int count )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( idPart ) )
				throw new ArgumentNullException( "idPart" );
			if ( fields == null )
				throw new ArgumentNullException( "fields" );

			// create the request
			var request = new RestRequest( "people/" + idPart + "/connections" + FieldSelector.ToFieldSelector( fields ) );

			// set the parameters
			request.AddParameter( "start", start );
			request.AddParameter( "count", count );

			// execute the request
			return ExecuteRequest< Connections >( request );
		}
		#endregion
	}
}