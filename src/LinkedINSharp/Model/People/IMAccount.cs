namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// An instant messenger account.
	/// </summary>
	public class IMAccount
	{
		#region Properties
		/// <summary>
		/// Possible values for im-account-type are: aim, gtalk, icq, msn, skype, and yahoo.
		/// </summary>
		public string IMAccountType { get; set; }
		/// <summary>
		/// The name of the account.
		/// </summary>
		public string IMAccountName { get; set; }
		#endregion
	}
}