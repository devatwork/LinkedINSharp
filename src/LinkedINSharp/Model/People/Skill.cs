namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A skill held by a member.
	/// </summary>
	public class Skill
	{
		#region Properties
		/// <summary>
		/// A unique identifier for a single skill in the list of skills.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A structured object that indicates the internationalized name of the canonical language
		/// </summary>
		public SkillName Name { get; set; }
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