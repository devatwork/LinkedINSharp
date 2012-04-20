using System.Collections.ObjectModel;

namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A patent applications held by this member.
	/// </summary>
	public class Patent
	{
		#region Properties
		/// <summary>
		/// A unique identifier for this member's patent entry.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// The patent title.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// short summary of the patent.
		/// </summary>
		public string Summary { get; set; }
		/// <summary>
		/// A string with the patent or application number.
		/// </summary>
		/// <remarks>
		/// Example: 7,720,722.
		/// </remarks>
		public string Number { get; set; }
		/// <summary>
		/// The status of the patent.
		/// </summary>
		public PatentStatus Status { get; set; }
		/// <summary>
		/// A string with the patent or application number.
		/// </summary>
		/// <remarks>
		/// Example: 7,720,722.
		/// </remarks>
		public PatentOffice Office { get; set; }
		/// <summary>
		/// The <see cref="Inventor"/>s of this patent.
		/// </summary>
		public Collection< Inventor > Inventors { get; set; }
		/// <summary>
		/// A structured object with day, month, and year fields indicating when the application was filed or when the patent was granted.
		/// </summary>
		/// <remarks>
		/// Each individual field is optional, but if month is populated, year must be populated, if day is populated, month must be populated.
		/// </remarks>
		public Date Date { get; set; }
		/// <summary>
		/// The URL to the patent.
		/// </summary>
		public string Url { get; set; }
		#endregion
	}
}