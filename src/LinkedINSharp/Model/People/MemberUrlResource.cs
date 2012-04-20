namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// An URL the member has chosen to share on their LinkedIn profile.
	/// </summary>
	public class MemberUrlResource
	{
		#region Properties
		/// <summary>
		/// The fully-qualified URL being shared.
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// The label given to the URL by the member.
		/// </summary>
		public string Name { get; set; }
		#endregion
	}
}