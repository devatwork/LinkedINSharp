namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A skill held by a member.
	/// </summary>
	public class SkillItem
	{
		#region Properties
		/// <summary>
		/// A unique identifier for a single skill in the list of skills.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A structured object that indicates the internationalized name of the canonical language
		/// </summary>
		public SkillName Skill { get; set; }
		/// <summary>
		/// A structured object indicating the user's skill level
		/// </summary>
		public SkillProficiency Proficiency { get; set; }
		/// <summary>
		/// A structured object describing the years of experience for this skill.
		/// </summary>
		public SkillYears Years { get; set; }
		#endregion
	}
}