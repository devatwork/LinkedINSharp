namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A volunteering experiences a member has participated in, including organizations and causes.
	/// </summary>
	public class Volunteer
	{
		#region Properties
		/// <summary>
		/// a unique identifier for this member's volunteer entries.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// the role the member has performed as a volunteer.
		/// </summary>
		public string Role { get; set; }
		/// <summary>
		/// the name of an organization the member has volunteered with.
		/// </summary>
		public string Organization { get; set; }
		/// <summary>
		/// a string describing causes the member has listed.
		/// </summary>
		public string Cause { get; set; }
		#endregion
	}
}