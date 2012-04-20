namespace LinkedINSharp.Model
{
	/// <summary>
	/// Base class for paged collections.
	/// </summary>
	public abstract class PagedCollection
	{
		#region Properties
		/// <summary>
		/// The total number of results.
		/// </summary>
		public int Total { get; set; }
		/// <summary>
		/// The start of the page of this collection.
		/// </summary>
		public int Start { get; set; }
		/// <summary>
		/// The number of results on this page.
		/// </summary>
		public int NumberOfResults { get; set; }
		#endregion
	}
}