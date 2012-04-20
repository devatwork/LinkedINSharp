namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// Represents an company.
	/// </summary>
	public class Company
	{
		#region Properties
		/// <summary>
		/// the ID for the company (useful with facets or the Company API)
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// the name of the company.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// indicates if the company is public or private
		/// </summary>
		public CompanyType Type { get; set; }
		/// <summary>
		/// the number of employees at the company.
		/// </summary>
		/// <remarks>
		/// Expressed as a range.
		/// </remarks>
		public string Size { get; set; }
		/// <summary>
		/// the industry in which the company operates.
		/// </summary>
		/// <seealso href="https://developer.linkedin.com/documents/industry-codes"/>
		public string Industry { get; set; }
		/// <summary>
		/// the stock market name for the company, if the company type is public.
		/// </summary>
		public string Ticker { get; set; }
		#endregion
	}
}