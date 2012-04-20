namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A Certification earned by a member.
	/// </summary>
	public class Certification
	{
		#region Properties
		/// <summary>
		/// A unique identifier for this certification.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A string indicating the name of this certification.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// The certification's issuing body.
		/// </summary>
		public CertificationAuthority Authority { get; set; }
		/// <summary>
		/// A string describing the license number for this certification.
		/// </summary>
		public string Number { get; set; }
		/// <summary>
		/// A structured object with day, month, and year fields indicating the start date for the certification.
		/// </summary>
		public Date StartDate { get; set; }
		/// <summary>
		/// A structured object with day, month, and year fields indicating the end date for the certification.
		/// </summary>
		public Date EndDate { get; set; }
		#endregion
	}
}