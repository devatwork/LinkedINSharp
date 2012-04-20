namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Represents an language.
	/// </summary>
	public class Language
	{
		#region Properties
		/// <summary>
		/// A unique identifier for a single language in the list of languages.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A structured object specifying the language name.
		/// </summary>
		/// <remarks>
		/// May be localized in the future.
		/// </remarks>
		public LanguageName Name { get; set; }
		/// <summary>
		/// The <see cref="LanguageProficiency"/>.
		/// </summary>
		public LanguageProficiency Proficiency { get; set; }
		#endregion
	}
}