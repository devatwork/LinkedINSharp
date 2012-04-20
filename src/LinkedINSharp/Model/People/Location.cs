namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Represents an location of the LinkedIn member.
	/// </summary>
	public class Location
	{
		/// <summary>
		/// Generic name of the location of the LinkedIn member, (ex: "San Francisco Bay Area")
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// The <see cref="Country"/>.
		/// </summary>
		public Country Country { get; set; }
	}
}