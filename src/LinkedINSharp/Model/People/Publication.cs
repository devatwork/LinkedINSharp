using System.Collections.ObjectModel;

namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// An publication authored by an member.
	/// </summary>
	public class Publication
	{
		#region Properties
		/// <summary>
		/// A unique identifier for this member's publication entry
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A string describing the title of this publication.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// The <see cref="Publisher"/> of this publication.
		/// </summary>
		public Publisher Publisher { get; set; }
		/// <summary>
		/// The <see cref="PublicationAuthor"/>s of this publication.
		/// </summary>
		public Collection< PublicationAuthor > Authors { get; set; }
		/// <summary>
		/// A structured object with day, month, and year fields indicating when the publication was published.
		/// </summary>
		/// <remarks>
		/// Each individual field is optional, but if month is populated, year must be populated, if day is populated, month must be populated.
		/// </remarks>
		public Date Date { get; set; }
		/// <summary>
		/// A URL for the publication.
		/// </summary>
		/// <remarks>
		/// Can either be the publication itself or a page with more information on the publication.
		/// </remarks>
		public string Url { get; set; }
		/// <summary>
		/// A string summary of the publication.
		/// </summary>
		public string Summary { get; set; }
		#endregion
	}
}