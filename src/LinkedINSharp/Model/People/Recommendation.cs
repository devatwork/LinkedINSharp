namespace LinkedINSharp.Model.People
{
	/// <summary>
	/// A recommendation a member has received.
	/// </summary>
	public class Recommendation
	{
		#region Properties
		/// <summary>
		/// a unique identifier for this recommendation.
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// indicates type of recommendation that was selected by the person making the recommendation.
		/// </summary>
		public string RecommendationType { get; set; }
		/// <summary>
		/// a collection defining the person who made the recommendation.
		/// </summary>
		public Person Recommender { get; set; }
		#endregion
	}
}