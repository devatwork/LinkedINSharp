namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A phone number.
	/// </summary>
	public class TelephoneNumber
	{
		#region Properties
		/// <summary>
		/// Possible values for phone-type are: home, work, and mobile.
		/// </summary>
		public string PhoneType { get; set; }
		/// <summary>
		/// The phone number.
		/// </summary>
		public string PhoneNumber { get; set; }
		#endregion
	}
}