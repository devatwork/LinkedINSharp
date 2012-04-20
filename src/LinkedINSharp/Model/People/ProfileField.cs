using System;

namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Enumerates all the profile fields
	/// </summary>
	/// <seealso href="https://developer.linkedin.com/documents/profile-fields"/>
	public class ProfileField : FieldSelector
	{
		#region Constructors
		/// <summary>
		/// Constructs an LinkedIN field.
		/// </summary>
		/// <param name="fieldName">The LinkedIN name of the field.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="fieldName"/> is null or empty.</exception>
		public ProfileField( string fieldName ) : base( fieldName )
		{
		}
		#endregion
		#region Values
		/// <summary>
		/// a unique identifier token for this member.
		/// </summary>
		public static readonly ProfileField Id = new ProfileField( "id" );
		/// <summary>
		/// the member's first name.
		/// </summary>
		public static readonly ProfileField FirstName = new ProfileField( "first-name" );
		/// <summary>
		/// the member's last name.
		/// </summary>
		public static readonly ProfileField LastName = new ProfileField( "last-name" );
		/// <summary>
		/// the member's maiden name.
		/// </summary>
		public static readonly ProfileField MaidenName = new ProfileField( "maiden-name" );
		#endregion
		#region Aggregates
		/// <summary>
		/// Selects the name fields only.
		/// </summary>
		public static readonly ProfileField[] NameOnly = new[] { Id, FirstName, LastName };
		/// <summary>
		/// Enumerates all the fields.
		/// </summary>
		public static readonly ProfileField[] All = new[] { Id, FirstName, LastName, MaidenName };
		#endregion
	}
}