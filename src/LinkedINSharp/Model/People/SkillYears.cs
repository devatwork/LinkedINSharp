namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A structured object describing the years of experience for this skill.
	/// </summary>
	public class SkillYears
	{
		#region Properties
		/// <summary>
		/// The ID form is an enumerated ID where the ID equals the number of years.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The name form is a string representation of the number of years.
		/// </summary>
		/// <remarks>
		/// For example: {&lt;1, 1, 2, 3, ... , 18, 19, 20+}
		/// </remarks>
		public string Name { get; set; }
		#endregion
	}
}