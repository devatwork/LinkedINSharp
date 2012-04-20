namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Describes the patent status.
	/// </summary>
	public class PatentStatus
	{
		#region Properties
		/// <summary>
		/// An ID indicating whether this is a granted patent or patent application.
		/// </summary>
		/// <remarks>
		/// Values are 0 for patent application; 1 for granted patent.
		/// </remarks>
		public string Id { get; set; }
		/// <summary>
		/// A string indicating whether this is a granted patent or patent application.
		/// </summary>
		/// <remarks>
		/// Values are Application and Patent.
		/// </remarks>
		public string Name { get; set; }
		#endregion
	}
}