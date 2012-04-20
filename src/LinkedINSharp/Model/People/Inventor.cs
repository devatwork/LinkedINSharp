namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Represents the inventor.
	/// </summary>
	public class Inventor
	{
		#region Properties
		/// <summary>
		/// A unique identifier for this inventor in the list of inventors.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A string that indicates the name of this inventor as it should be displayed.
		/// </summary>
		/// <remarks>
		/// This is the name as it appears on the patent (which can differ from a person's name on LinkedIn).
		/// </remarks>
		public string Name { get; set; }
		/// <summary>
		/// An optional field that shows the LinkedIn member object for this particular member.
		/// </summary>
		/// <remarks>
		/// Default values are id, first-name, and last-name.
		/// </remarks>
		public Person Person { get; set; }
		#endregion
	}
}