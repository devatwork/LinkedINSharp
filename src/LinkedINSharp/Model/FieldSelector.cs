using System;
using System.Collections.Generic;
using System.Linq;
using LinkedINSharp.Model.People;

namespace LinkedINSharp.Model
{
	/// <summary>
	/// Represents a field selector.
	/// </summary>
	/// <seealso href="https://developer.linkedin.com/documents/field-selectors"/>
	public abstract class FieldSelector
	{
		#region Constructors
		/// <summary>
		/// Constructs an LinkedIN field.
		/// </summary>
		/// <param name="fieldName">The LinkedIN name of the field.</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="fieldName"/> is null or empty.</exception>
		protected FieldSelector( string fieldName )
		{
			// validate arguments
			if ( string.IsNullOrEmpty( fieldName ) )
				throw new ArgumentNullException( "fieldName" );

			// set value
			this.fieldName = fieldName;
		}
		#endregion
		#region Format Functions
		/// <summary>
		/// Formats all the <paramref name="fields"/> into a LinkedIN field selector.
		/// </summary>
		/// <param name="fields">The <see cref="ProfileField"/>s.</param>
		/// <returns>Returns the formatted field selector.</returns>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="fields"/> is null.</exception>
		public static string ToFieldSelector( IEnumerable< FieldSelector > fields )
		{
			// validate argumetns
			if ( fields == null )
				throw new ArgumentNullException( "fields" );
			var fieldArray = fields.ToArray();
			if ( fieldArray.Length < 1 )
				return string.Empty;

			return ":(" + string.Join( ",", fieldArray.Select( field => field.fieldName ) ) + ")";
		}
		#endregion
		#region Overrides of Object
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString()
		{
			return "field: " + fieldName;
		}
		#endregion
		#region Private Fields
		private readonly string fieldName;
		#endregion
	}
}