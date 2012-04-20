namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// An education institution a member has attended.
	/// </summary>
	public class Education
	{
		#region Properties
		/// <summary>
		/// a unique identifier for this member's education entry.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// the name of the school, as indicated by the member.
		/// </summary>
		public string SchoolName { get; set; }
		/// <summary>
		/// the field of study at the school, as indicated by the member.
		/// </summary>
		public string FieldOfStudy { get; set; }
		/// <summary>
		/// a structured object a year field indicating when the education began.
		/// </summary>
		public Date StartDate { get; set; }
		/// <summary>
		/// a structured object with a year field indicating when the education ended.
		/// </summary>
		/// <remarks>
		/// Blank when the education is current.
		/// </remarks>
		public Date EndDate { get; set; }
		/// <summary>
		/// a string describing the degree, if any, received at this institution.
		/// </summary>
		public string Degree { get; set; }
		/// <summary>
		/// a string describing activities the member was involved in while a student at this institution.
		/// </summary>
		public string Activities { get; set; }
		/// <summary>
		/// a string describing other details on the member's studies.
		/// </summary>
		public string Notes { get; set; }
		#endregion
	}
}