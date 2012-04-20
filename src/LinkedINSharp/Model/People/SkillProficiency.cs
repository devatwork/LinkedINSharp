namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A structured object indicating the user's skill level.
	/// </summary>
	public class SkillProficiency
	{
		#region Properties
		/// <summary>
		/// A structured object indicating the user's skill level. Returns one of the four following values.
		/// - beginner
		/// - intermediate
		/// - advanced
		/// - expert
		/// </summary>
		/// <remarks>
		/// This field is for computer programs.
		/// </remarks>
		public string Level { get; set; }
		/// <summary>
		/// A structured object specifying the user's skill level name.
		/// - Beginner
		/// - Intermediate
		/// - Advanced
		/// - Expert
		/// </summary>
		/// <remarks>
		/// This field is for humans to read. It may be localized in the future.
		/// </remarks>
		public string Name { get; set; }
		#endregion
	}
}