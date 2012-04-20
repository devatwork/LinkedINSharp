namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Language proficiency.
	/// </summary>
	public class LanguageProficiency
	{
		#region Properties
		/// <summary>
		/// A structured object indicating the user's fluency. Returns one of the following five values:
		/// - elementary
		/// - limited-working
		/// - professional-working
		/// - full-professional
		/// - native-or-bilingual
		/// </summary>
		/// <remarks>
		/// This field is for computer programs.
		/// </remarks>
		public string Level { get; set; }
		/// <summary>
		/// A structured object specifying the user's fluency by name.
		/// - Elementary proficiency
		/// - Limited working proficiency
		/// - Professional working proficiency
		/// - Full professional proficiency
		/// - Native or bilingual proficiency
		/// </summary>
		/// <remarks>
		/// This field is for humans to read. It may be localized in the future.
		/// </remarks>
		public string Name { get; set; }
		#endregion
	}
}