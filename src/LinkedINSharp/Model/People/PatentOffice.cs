namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// The patent office.
	/// </summary>
	public class PatentOffice
	{
		#region Properties
		/// <summary>
		/// A structured object describing the patent issuing body.
		/// </summary>
		/// <remarks>
		/// Example: for the USPTO, the value is us.
		/// </remarks>
		public string Name { get; set; }
		#endregion
	}
}