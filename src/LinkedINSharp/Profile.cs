using System;
using LinkedINSharp.Model.People;
using RestSharp;

namespace LinkedINSharp
{
	/// <summary>
	/// Implements the LinkedIN profile api part for the LinkedIN rest client.
	/// </summary>
	/// <seealso href="https://developer.linkedin.com/documents/profile-api"/>
	public partial class LinkedINRestClient
	{
		#region Retrieve Profile Methods
		/// <summary>
		/// Retrieves the <see cref="Person"/> profile of the currently authorized member.
		/// </summary>
		/// <param name="fields">The <see cref="ProfileField"/>s  which to load int the <see cref="Person"/>.</param>
		/// <returns>Returns the <see cref="Person"/> with the specified <paramref name="fields"/> loaded.</returns>
		/// /// <exception cref="ArgumentNullException">Thrown when <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		public Person RetrieveCurrentMemberProfile( ProfileField[] fields )
		{
			return RetrieveProfileById( "~", fields );
		}
		/// <summary>
		/// Retrieves the <see cref="Person"/> of the member identified by his/her <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The ID of the member.</param>
		/// <param name="fields">The <see cref="ProfileField"/>s  which to load int the <see cref="Person"/>.</param>
		/// <returns>Returns the <see cref="Person"/> with the specified <paramref name="fields"/> loaded.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> or <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		public Person RetrieveMemberProfileById( string id, ProfileField[] fields )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( "idPart" ) )
				throw new ArgumentNullException( "id" );

			return RetrieveProfileById( "idPart=" + id, fields );
		}
		/// <summary>
		/// Retrieves an <see cref="Person"/> by it's <paramref name="idPart"/>.
		/// </summary>
		/// <param name="idPart">The identifying part.</param>
		/// <param name="fields">The <see cref="ProfileField"/>s  which to load int the <see cref="Person"/>.</param>
		/// <returns>Returns the <see cref="Person"/> with the specified <paramref name="fields"/> loaded.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="idPart"/> or <paramref name="fields"/> is null.</exception>
		/// <exception cref="LinkedINHttpResponseException">Thrown when the an unexepcted response was returned from LinkedIN.</exception>
		/// <exception cref="LinkedINUnauthorizedException">Thrown when an request was made to an protected resource without the proper authorization.</exception>
		protected Person RetrieveProfileById( string idPart, ProfileField[] fields )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( "idPart" ) )
				throw new ArgumentNullException( "idPart" );
			if ( fields == null )
				throw new ArgumentNullException( "fields" );

			// create the request
			var request = new RestRequest( "people/" + idPart + ProfileField.ToFieldSelector( fields ) );

			// execute the request
			return ExecuteRequest< Person >( request );
		}
		#endregion
	}
}