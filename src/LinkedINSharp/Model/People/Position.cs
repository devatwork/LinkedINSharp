namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A positions a member has had.
	/// </summary>
	public class Position
	{
		#region Properties
		/// <summary>
		/// a unique identifier for this member's position.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// the job title held at the position, as indicated by the member.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// a summary of the member's position.
		/// </summary>
		public string Summary { get; set; }
		/// <summary>
		/// a structured object with month and year fields indicating when the position began.
		/// </summary>
		public Date StartDate { get; set; }
		/// <summary>
		/// a structured object with month and year fields indicating when the position ended
		/// </summary>
		public Date EndDate { get; set; }
		/// <summary>
		/// a "true" or "false" value, depending on whether it is marked current
		/// </summary>
		public bool IsCurrent { get; set; }
		/// <summary>
		/// the company the member works for.
		/// </summary>
		public Company Company { get; set; }
		#endregion
	}
}