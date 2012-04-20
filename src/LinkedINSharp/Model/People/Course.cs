namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A course a member has taken.
	/// </summary>
	public class Course
	{
		#region Properties
		/// <summary>
		/// a unique identifier for this member's course entries.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// a string identifying the name of the course, as entered by the member.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// the course number assigned, as entered by the member.
		/// </summary>
		public string Number { get; set; }
		#endregion
	}
}