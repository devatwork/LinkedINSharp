namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Author of an <see cref="Publication"/>.
	/// </summary>
	public class PublicationAuthor
	{
		#region Properties
		/// <summary>
		/// A unique identifier for this author in the list of authors.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// A string that indicates the name of this author as it should be displayed.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// An optional field that displays the default LinkedIn member name (person field) for this particular member.
		/// </summary>
		public Person Person { get; set; }
		#endregion
	}
}