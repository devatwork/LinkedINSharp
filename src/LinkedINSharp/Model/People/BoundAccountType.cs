namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// An account bound by a member.
	/// </summary>
	public class BoundAccountType
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public string AccountType { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string BindingStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool IsPrimary { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ProviderAccountId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ProviderAccountName { get; set; }
		#endregion
	}
}